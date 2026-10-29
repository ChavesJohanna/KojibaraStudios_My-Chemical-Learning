using UnityEngine;
using UnityEngine.EventSystems;

public class AbrirInventario : MonoBehaviour, IPointerDownHandler
{
    private GameObject panel;
    private bool inveAbierto = false;
    private Inventario inventario;

    private void Start()
    {
        Transform padre = transform.parent;

        if (padre == null)
            return;

        Transform panelTransform = padre.Find("Panel");

        if (panelTransform == null)
            return;

        panel = panelTransform.gameObject;
        panel.SetActive(false);

        inventario = GetComponentInParent<Inventario>();

        if (DesbloqueoElementos.Instance != null)
        {
            DesbloqueoElementos.Instance.ObtenerEspaciosInventario(panel);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (panel == null || inventario == null)
            return;

        inveAbierto = !inveAbierto;
        panel.SetActive(inveAbierto);
        inventario.PanelAbierto(inveAbierto);
    }
}