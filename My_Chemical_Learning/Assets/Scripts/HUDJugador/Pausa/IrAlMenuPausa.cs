using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class IrAlMenuPausa : MonoBehaviour, IPointerDownHandler //se encuantra en el boton con el mismo nombre del panel de pausa
{
    private Pausa pausa; //componente del objeto con el msmo nombre

    private void Start()
    {
        pausa = transform.parent.GetComponentInParent<Pausa>(); //obtiene el componente que se encuentra en "Pausa"
    }

    public void OnPointerDown(PointerEventData eventData) //se ejecuta al presionar el boton
    {
        pausa.AbrirPanel(false); //desactiva la pausa y el panel

        SceneManager.LoadScene("MenuPrincipal");
    }


}
