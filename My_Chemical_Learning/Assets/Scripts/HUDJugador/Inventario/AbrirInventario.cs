using UnityEngine;
using UnityEngine.EventSystems;

public class AbrirInventario : MonoBehaviour, IPointerDownHandler //el script se encuntra en el boton Abrir dentro del objeto Inventario
{
    private GameObject panel; //el panel del inventario
    private bool inveAbierto = false;

    private void Start()
    {
        panel = transform.parent.transform.Find("ControladorEspacios").gameObject; //busca a su hermano llamado Panel
        panel.SetActive(false); //desactivado al inicio
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        inveAbierto = !inveAbierto; //osila entre true y false al tocar el boton

        panel.SetActive(inveAbierto);
    }


}
