using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PoolElementos : MonoBehaviour
{
    public static PoolElementos Instance { get; private set; }

    private Dictionary<string, Queue<GameObject>> pool =
        new Dictionary<string, Queue<GameObject>>();

    private string[] nombres =  //el prefab adresable debe tener el "label" con el mismo nombre que esta aqui
    {
        "Agua",
        "Sal",
        "Helio"
    };

    private int cantidad = 5;

    private string key; //este sera usado para asignar el elemento cuando se este activo un atajo

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        foreach (string nombre in nombres)
        {
            pool[nombre] = new Queue<GameObject>();

            for (int i = 0; i < cantidad; i++)
            {
                CrearElemento(nombre);
            }
        }
    }

    private void CrearElemento(string nombre)
    {
        Addressables.InstantiateAsync(nombre).Completed += (resultado) =>
        {
            if (resultado.Status != AsyncOperationStatus.Succeeded)
                return;

            GameObject elemento = resultado.Result;

            elemento.transform.SetParent(transform);
            elemento.SetActive(false);

            pool[nombre].Enqueue(elemento);
        };
    }

    public void ActivarElemento(string nombre)
    {
        if (nombre == "") //si el nombre es vacio que retorne
            return;

        if (nombre == null)
            return;

        this.key = nombre;

 
    }

    public GameObject AsignarPosicionElemento(Transform posicion)
    {
        if (!pool.ContainsKey(key)) //retorna si el nombre no coincide con alguno exixtente
            return null;

        if (pool[key].Count == 0) //si el pool esta vacio retorna
            return null;

        GameObject elemento = pool[key].Dequeue();

        elemento.transform.position = posicion.position; //asigna la posicion recibida al elemento
        elemento.transform.rotation = posicion.rotation;

        elemento.SetActive(true);

        return elemento;
    }

    public void DevolverElemento(string nombre, GameObject elemento)
    {
        elemento.SetActive(false);

        pool[nombre].Enqueue(elemento);
    }

    public bool ElementoNoElegido() //si no se eligio elemento tira true
    {
        return key == null || key == "";
    }
}
