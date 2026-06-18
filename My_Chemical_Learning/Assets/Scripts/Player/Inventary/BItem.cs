using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BItem : MonoBehaviour, IPointerClickHandler
{
    private Image imgItem;

    private void Start()
    {
        imgItem = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SwapItem.Instance.SelectImage(imgItem);

        Debug.Log("boton del inventario PRESIONADO");
    }
}
