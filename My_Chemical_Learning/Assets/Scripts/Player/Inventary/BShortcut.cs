using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BShortcut : MonoBehaviour, IPointerClickHandler
{
    private Image imgItem;

    private GameObject imgSelect;

    void Start()
    {
        imgItem = transform.GetChild(0).GetComponent<Image>();

        imgSelect = transform.GetChild(1).gameObject;
    }

   
    public void OnPointerClick(PointerEventData eventData)
    {
        SwapItem.Instance.SelectImage(imgItem);

        Debug.Log("boton shortcut PRESIONADO");

        imgSelect.SetActive(!imgSelect.activeSelf);
    }
}
