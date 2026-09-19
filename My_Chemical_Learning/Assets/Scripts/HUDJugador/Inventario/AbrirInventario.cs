using UnityEngine;
using UnityEngine.EventSystems;

public class AbrirInventario : MonoBehaviour, IPointerDownHandler //el script se encuntra en el boton Abrir dentro del objeto Inventario
{
    private GameObject panel; //el panel del inventario
    private bool inveAbierto = false;

    private Inventario inventario;
    private void Start()
    {
        panel = transform.parent.transform.Find("Panel").gameObject; //busca a su hermano llamado Panel
        panel.SetActive(false); //desactivado al inicio

        inventario = GetComponentInParent<Inventario>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        inveAbierto = !inveAbierto; //osila entre true y false al tocar el boton

        panel.SetActive(inveAbierto);
        inventario.PanelAbierto(inveAbierto); //le avisa al inventario que el panel asta abierto o cerado 
    }


}
