using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BShortcut : MonoBehaviour, IPointerClickHandler
{
    private GameObject imgSelect;
    private Image imgItem;

    private string type; // el tipo de item que esta en el su componente imagen

    private Sprite lastSprite;

    private void Start()
    {
        imgSelect = transform.Find("ImgSelect").gameObject;

        imgItem = transform.Find("ImgItem").GetComponent<Image>();

        RefreshShortcut();
    }

    public void UpdateType()
    {
        if (imgItem.sprite == null)
        {
            type = "none";
            Debug.LogWarning("El shortcut no tiene sprite asignado");
            return;
        }

        string current = imgItem.sprite.name;

        if (current.Contains("item_Agua"))
        {
            type = "Water";
        }
        else if (current.Contains("item_Sal"))
        {
            type = "Salt";
        }
        else if (current.Contains("item_Helio"))
        {
            type = "Helium";
        }
        else
        {
            type = "none";
            Debug.LogWarning("Tipo no reconocido: " + current);
        }

        Debug.Log("Tipo detectado en shortcut: " + type);
    }

    public void RefreshShortcut()
    {
        if (imgItem.sprite != lastSprite)
        {
            lastSprite = imgItem.sprite;
            UpdateType();

            if (imgSelect.activeSelf)
            {
                ItemPool.Instance.Key(type);
                Debug.Log("Key actualizada tras swap: " + type);
            }
        }
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        imgSelect.SetActive(!imgSelect.activeSelf);

        lastSprite = imgItem.sprite;

        UpdateType();

        ItemPool.Instance.Key(type);

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
