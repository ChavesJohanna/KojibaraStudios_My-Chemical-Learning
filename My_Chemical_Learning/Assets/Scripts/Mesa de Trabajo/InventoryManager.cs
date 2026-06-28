using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    public List<string> elementosConseguidos = new List<string>();

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

    public void AgregarElementoConseguido(string nombre)
    {
        if (!elementosConseguidos.Contains(nombre))
        {
            elementosConseguidos.Add(nombre);
            Debug.Log($"Agregado al inventario: {nombre}");
        }
    }

    public bool TieneElemento(string nombre)
    {
        return elementosConseguidos.Contains(nombre);
    }
}