using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ItemPool : MonoBehaviour
{
    public static ItemPool Instance { get; private set; }

    private Dictionary<string, Queue<GameObject>> pool = new Dictionary<string, Queue<GameObject>>();

    private string[] tags = new string[]
    {
        "Water",
        "Salt"
    };

    private string currentKey;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        foreach (string tag in tags)
        {
            pool[tag] = new Queue<GameObject>();

            for (int i = 0; i < 5; i++)
            {
                // Instanciamos el Addressable usando el tag como Address
                Addressables.InstantiateAsync(tag).Completed += (op) =>
                {
                    if (op.Status == AsyncOperationStatus.Succeeded)
                    {
                        GameObject obj = op.Result;

                        obj.transform.SetParent(this.transform); //hacemos q sean hijos del pool

                        obj.SetActive(false);
                        pool[tag].Enqueue(obj);
                    }
                };
            }
        }
    }
    public void Key(string k)
    {
        Debug.Log("clave recibida en el pool " + k);

        currentKey = k;
    }

    public void Position(Transform pos, float dir)
    {
        if (currentKey == null || !pool.ContainsKey(currentKey))
        {
            Debug.LogWarning("la key no ha sido correctamente seteada o no se encuentra");
            return;
        }

        if (pool.ContainsKey(currentKey) && pool[currentKey].Count > 0)
        {
            GameObject obj = pool[currentKey].Dequeue();

            // Configuración del objeto
            obj.transform.position = pos.position;
            obj.transform.rotation = pos.rotation;
            obj.SetActive(true);

            // Si el objeto tiene un componente que implementa IItem
            if (obj.TryGetComponent(out IItem item))
            {
                item.Item(dir);
            }

        }
        else
        {
            Debug.LogWarning($"No hay objetos disponibles en el pool para la key: {currentKey}");
        }

        Debug.Log("el pool recibio la pos y dir correctamente");
    }

    // Método para regresar el objeto al pool
    public void ReturnToPool(string myKey, GameObject obj)
    {
        if (pool.ContainsKey(myKey))
        {
            obj.SetActive(false);
            pool[myKey].Enqueue(obj);
        }
        else
        {
            Debug.LogError($"El pool no contiene una cola para la clave: {myKey}");
        }
    }
}
