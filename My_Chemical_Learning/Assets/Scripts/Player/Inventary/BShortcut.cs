using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BShortcut : MonoBehaviour, IPointerClickHandler
{
    private GameObject imgSelect;
    private Image imgItem;

    private string type; // el tipo de item que esta en el su componente imagen

    private void Start()
    {
        imgSelect = transform.Find("ImgSelect").gameObject;

        imgItem = transform.Find("ImgItem").GetComponent<Image>();

        UpdateType();
    }

    public void UpdateType()
    {
        string current = imgItem.sprite.name;

        if (current.Contains("item_Agua"))
        {
            type = "Water";
        }
        else
        {
            type = "none";
            Debug.LogWarning("Tipo no reconocido: " + current);
        }

        ItemPool.Instance.Key(type);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        imgSelect.SetActive(!imgSelect.activeSelf);

        if (imgSelect.activeSelf)
        {
            ItemPool.Instance.Key(type);
        }
    }

    public bool ShortcutActive() // sirve par q el boton de usar solo dispare al estar el rojo 
    {
        return imgSelect.activeSelf;
    }

    public Image GetImgItem() // para el intercambio con los del inventario
    {
        return imgItem;
    }

}
