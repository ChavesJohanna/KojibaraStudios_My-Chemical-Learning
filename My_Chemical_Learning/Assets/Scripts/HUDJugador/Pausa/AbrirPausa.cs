using UnityEngine;
using UnityEngine.EventSystems;

public class AbrirPausa : MonoBehaviour, IPointerDownHandler //el script se encuntra en el boton Abrir dentro del objeto Pausa
{
    private Pausa pausa;

    private void Start()
    {
        pausa = GetComponentInParent<Pausa>(); //obtiene el componente del padre
    }

    public void OnPointerDown(PointerEventData eventData) //se ejecuta al tocar el boton
    {
        pausa.AbrirPanel(true); //activa el panel
    }

}
