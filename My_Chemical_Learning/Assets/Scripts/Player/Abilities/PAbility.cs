using UnityEngine;
using UnityEngine.AddressableAssets;

public class PAbility : MonoBehaviour, IUseItem 
{
    private Rigidbody2D rb;

    private float lastDirectionX = 1f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.linearVelocity.x > 0.1f)
            lastDirectionX = 1f;
        else if (rb.linearVelocity.x < -0.1f)
            lastDirectionX = -1f;
    }
    public async void UseItem()
    {
        Transform spawnPoint = transform;

        string nombreItem = SelectItem.Instance.NameI();

        if (nombreItem == null) return;

        // Usamos la espera aquí dentro. 
        // El resto del programa NO se detendrá, solo este método.
        var handle = Addressables.InstantiateAsync(nombreItem, spawnPoint.position, Quaternion.identity);

        // Esperamos a que la operación se complete
        GameObject miObjeto = await handle.Task;

        // Verificamos que la carga fue exitosa
        if (handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
        {
            var item = miObjeto.GetComponent<IItem>();
            if (item != null)
            {
                item.Execute(lastDirectionX);

                Debug.Log("mandando la direccion a la awa");
            }
        }
        else
        {
            Debug.LogError("Error al instanciar el Addressable: " + nombreItem);
        }
    }
}
