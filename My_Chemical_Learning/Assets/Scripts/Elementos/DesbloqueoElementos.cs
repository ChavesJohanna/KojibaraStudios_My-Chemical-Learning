using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DesbloqueoElementos : MonoBehaviour //se encarga de los sprites que estan en el inventario y sirve para el desbloqueo de los mismos
{
    public static DesbloqueoElementos Instance { get; private set; }

 
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    private string[] nombres = new string[]
    {
        "item_Agua",
        "item_Sal",
        "item_Helio",
        "item_Acido",
        "item_Nitrogeno",
        "item_OxAlum",
    };
    private Sprite[] sprites;
    private Image[] comp;

    private GameObject inventario;

    private string elemento;

    private int indice; //nos ayudadra a colocar el sprite en el lugar q corresponda


    private Dictionary<int, int> map = new Dictionary<int, int>();

    private Sprite spriteVacio;

    private void Start()
    {
        sprites = new Sprite[nombres.Length];

        for (int i = 0; i < nombres.Length; i++)
        {
            sprites[i] = Resources.Load<Sprite>("SpritesElementos/"+nombres[i]); //guaramos los sprites en el array 
        }

        spriteVacio = Resources.Load<Sprite>("SpritesElementos/item_Vacio");
    }

    public void ObtenerEspaciosInventario(GameObject inve) //recibe el panel del inventario
    {
        if (inventario == inve) //evitamos que se reasigne cada que se reinicie la escena
            return;

        inventario = inve;

        comp = new Image[inve.transform.childCount]; //determinamos el tamaño segun la cantidad de espacios del inventario

        for (int i = 0; i < comp.Length; i++)
        {
            comp[i] = inve.transform.GetChild(i).GetComponent<Image>(); //guardamos los componentes en el array
        }
    }

    
    public void AsignarElementoInventario(string tipo) //se utiliza para desbloquear el eleneto segun en nombre quese le pase ej "Agua"
    {
        if (elemento == tipo) //evitamos que se resasigne si son iguales
            return;

        elemento = tipo;

        int indiceSprite = Array.IndexOf(nombres, "item_" + tipo); //busca en el array de nombre el item desbloqueado

        if (indiceSprite == -1) //si no existe el nombre del elelmnto ene el array entonces retorna
            return;

        if (indice >= comp.Length)
            return;

        comp[indice].sprite = sprites[indiceSprite];

        indice++;

        ActualizarElementoInventario();
    }

    public void ActualizarElementoInventario() //actualiza los sprites que se encuentran en cada uno de los componentes de los espacios del inventario
    {
        map.Clear();

        for (int i = 0; i < comp.Length; i++)
        {
            Sprite spriteActual = comp[i].sprite;

            if (spriteActual == null)
                continue;

            int indiceSprite = Array.IndexOf(sprites, spriteActual);

            if (indiceSprite == -1)
                continue;

            map[i] = indiceSprite;

        }
    }
    public Sprite ObtenerSpriteGuardado(int indice) //devuelve es sprite ya guardado cosa de colocarse al momneto de reiniciar el nivel o pasarlo
    {
        if (!map.ContainsKey(indice))
            return spriteVacio;

        return sprites[map[indice]];
    }

}
