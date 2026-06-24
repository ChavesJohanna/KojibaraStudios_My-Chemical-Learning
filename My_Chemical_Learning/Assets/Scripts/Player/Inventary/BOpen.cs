using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BOpen : MonoBehaviour, IPointerClickHandler
{
    private GameObject iPanel;

    private void Start()
    {
        Transform parent = transform.parent.transform;

        iPanel = parent.Find("IPanel").gameObject;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        iPanel.SetActive(!iPanel.activeSelf);

        Debug.Log("boton ABRIR INVENTARIO presionado");
    }

}
