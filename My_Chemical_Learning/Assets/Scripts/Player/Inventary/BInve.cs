using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BInve : MonoBehaviour, IPointerClickHandler
{
    private GameObject panel;

    void Start()
    {
        GameObject parent = transform.parent.gameObject;
        panel = parent.transform.Find("Panel").gameObject;
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        panel.SetActive(!panel.activeSelf);

        Debug.Log("boton ABRIR INVENTARIO presionado");
    }
}
