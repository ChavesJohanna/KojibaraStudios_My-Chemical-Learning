
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    // Elementos desbloqueados durante el nivel actual.
    public List<string> elementosConseguidos = new List<string>();

    private string ultimaEscena;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        ultimaEscena = SceneManager.GetActiveScene().name;

        // Permite conservar los elementos al entrar en MesaTrabajo.
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += AlCargarEscena;
    }

    private void OnDestroy()
    {
        if (Instance != this)
            return;

        SceneManager.sceneLoaded -= AlCargarEscena;
        Instance = null;
    }

    // Vacía el inventario solo al pasar directamente de una escena
    // a otra distinta, excepto al entrar o salir de MesaTrabajo.
    private void AlCargarEscena(Scene escena, LoadSceneMode modo)
    {
        string nuevaEscena = escena.name;

        bool entraEnMesa = nuevaEscena == "MesaTrabajo";
        bool vieneDeMesa = ultimaEscena == "MesaTrabajo";
        bool cambiaDeNivel = nuevaEscena != ultimaEscena;

        if (cambiaDeNivel && !entraEnMesa && !vieneDeMesa)
            elementosConseguidos.Clear();

        ultimaEscena = nuevaEscena;
    }

    // Registra cada elemento una sola vez.
    public void AgregarElementoConseguido(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return;

        if (!elementosConseguidos.Contains(id))
            elementosConseguidos.Add(id);
    }

    public bool TieneElemento(string id)
    {
        return elementosConseguidos.Contains(id);
    }
}
