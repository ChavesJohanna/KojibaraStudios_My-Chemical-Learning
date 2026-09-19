using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Espacio : MonoBehaviour, IPointerDownHandler //se encuentra en los botones con el mismo nombre
{
    private ControladorEspacios controlador;
    private Image elemento; //el sprite que tiene el espacio del inventario

    private void Start()
    {
        controlador = GetComponentInParent<ControladorEspacios>();
        elemento = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (controlador == null)
            return;

        controlador.Seleccionar(this, elemento.sprite);

        Debug.Log("Espacio elegido: " + gameObject.name);
    }
}
