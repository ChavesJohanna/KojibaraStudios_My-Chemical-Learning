using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DesbloqueoElementos : MonoBehaviour
{
    public static DesbloqueoElementos Instance { get; private set; }

    private readonly string[] nombres =
    {
        "item_Agua",
        "item_Sal",
        "item_Helio",
        "item_Acido",
        "item_Nitrogeno",
        "item_OxAlum"
    };

    private Sprite[] sprites;
    private Sprite spriteVacio;
    private Image[] comp;

    // Guarda el contenido visual de cada espacio por nombre de elemento.
    private readonly List<string> estadoEspacios = new List<string>();

    // Impide desbloquear el mismo elemento más de una vez en el nivel.
    private readonly HashSet<string> elementosDesbloqueados =
        new HashSet<string>();

    // Elementos fabricados mientras no hay un panel de inventario activo.
    private readonly List<string> elementosPendientes = new List<string>();

    private string ultimaEscena;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        ultimaEscena = SceneManager.GetActiveScene().name;

        // Carga los sprites antes de registrar el panel de inventario.
        sprites = new Sprite[nombres.Length];

        for (int i = 0; i < nombres.Length; i++)
        {
            sprites[i] = Resources.Load<Sprite>(
                "SpritesElementos/" + nombres[i]
            );
        }

        spriteVacio = Resources.Load<Sprite>(
            "SpritesElementos/item_Vacio"
        );

        SceneManager.sceneLoaded += AlCargarEscena;
    }

    private void OnDestroy()
    {
        if (Instance != this)
            return;

        SceneManager.sceneLoaded -= AlCargarEscena;
        Instance = null;
    }

    private void AlCargarEscena(Scene escena, LoadSceneMode modo)
    {
        string nuevaEscena = escena.name;

        // Las imágenes de la escena anterior ya no deben utilizarse.
        comp = null;

        // Al entrar a un nivel diferente, reinicia los elementos.
        // La ida y vuelta a MesaTrabajo conserva el inventario.
        bool entraANivel = nuevaEscena.StartsWith("Nivel");
        bool vieneDeMesa = ultimaEscena == "MesaTrabajo";

        if (entraANivel && !vieneDeMesa)
        {
            ReiniciarDatos();

            if (GuardadoAtajos.Instance != null)
            {
                GuardadoAtajos.Instance.ReiniciarAtajos();
            }
        }

        ultimaEscena = nuevaEscena;
    }

    public void ObtenerEspaciosInventario(GameObject inve)
    {
        if (inve == null)
            return;

        // Obtiene las imágenes que pertenecen al panel de la escena actual.
        List<Image> imagenes = new List<Image>();

        for (int i = 0; i < inve.transform.childCount; i++)
        {
            Image imagen = inve.transform.GetChild(i).GetComponent<Image>();

            if (imagen != null)
                imagenes.Add(imagen);
        }

        comp = imagenes.ToArray();

        // Restaura los espacios guardados y coloca los elementos pendientes.
        RestaurarEspacios();
        ColocarElementosPendientes();
        ActualizarElementoInventario();
    }

    public void AsignarElementoInventario(string tipo)
    {
        if (string.IsNullOrWhiteSpace(tipo))
            return;

        int indiceSprite = Array.IndexOf(nombres, "item_" + tipo);

        if (indiceSprite == -1)
            return;

        // Evita fabricar y registrar dos veces el mismo desbloqueo.
        if (!elementosDesbloqueados.Add(tipo))
            return;

        // Si no hay panel activo, el elemento espera hasta volver al nivel.
        elementosPendientes.Add(tipo);

        if (comp != null)
            ColocarElementosPendientes();
    }

    private void RestaurarEspacios()
    {
        if (comp == null)
            return;

        for (int i = 0; i < comp.Length; i++)
        {
            if (comp[i] == null)
                continue;

            comp[i].sprite = spriteVacio;

            if (i >= estadoEspacios.Count)
                continue;

            string tipo = estadoEspacios[i];

            if (string.IsNullOrEmpty(tipo))
                continue;

            int indiceSprite = Array.IndexOf(nombres, "item_" + tipo);

            if (indiceSprite >= 0)
                comp[i].sprite = sprites[indiceSprite];
        }
    }

    private void ColocarElementosPendientes()
    {
        if (comp == null || elementosPendientes.Count == 0)
            return;

        // Coloca cada elemento nuevo en el primer espacio vacío disponible.
        for (int p = elementosPendientes.Count - 1; p >= 0; p--)
        {
            string tipo = elementosPendientes[p];
            int indiceSprite = Array.IndexOf(nombres, "item_" + tipo);

            if (indiceSprite == -1)
            {
                elementosPendientes.RemoveAt(p);
                continue;
            }

            int espacioLibre = BuscarEspacioLibre();

            if (espacioLibre == -1)
                continue;

            if (comp[espacioLibre] == null)
                continue;

            comp[espacioLibre].sprite = sprites[indiceSprite];
            elementosPendientes.RemoveAt(p);
        }
    }

    private int BuscarEspacioLibre()
    {
        if (comp == null)
            return -1;

        for (int i = 0; i < comp.Length; i++)
        {
            if (comp[i] == null)
                continue;

            if (comp[i].sprite == null || comp[i].sprite == spriteVacio)
                return i;
        }

        return -1;
    }

    public void ActualizarElementoInventario()
    {
        if (comp == null)
            return;

        // Guarda la distribución actual sin modificar los sprites.
        estadoEspacios.Clear();

        for (int i = 0; i < comp.Length; i++)
        {
            if (comp[i] == null || comp[i].sprite == null ||
                comp[i].sprite == spriteVacio)
            {
                estadoEspacios.Add("");
                continue;
            }

            int indiceSprite = Array.IndexOf(sprites, comp[i].sprite);

            if (indiceSprite == -1)
            {
                estadoEspacios.Add("");
                continue;
            }

            estadoEspacios.Add(nombres[indiceSprite].Substring(5));
        }
    }

    public Sprite ObtenerSpriteGuardado(int indice)
    {
        if (comp == null || indice < 0 || indice >= comp.Length)
            return spriteVacio;

        if (comp[indice] == null || comp[indice].sprite == null)
            return spriteVacio;

        return comp[indice].sprite;
    }

    public void ReiniciarElementos()
    {
        ReiniciarDatos();

        // Si el panel actual sigue activo, deja todos sus espacios vacíos.
        if (comp != null)
        {
            for (int i = 0; i < comp.Length; i++)
            {
                if (comp[i] != null)
                    comp[i].sprite = spriteVacio;
            }
        }
    }

    private void ReiniciarDatos()
    {
        estadoEspacios.Clear();
        elementosDesbloqueados.Clear();
        elementosPendientes.Clear();
    }
}