using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BSlot : MonoBehaviour, IPointerClickHandler
{
    private Image myImage;

    private void Start()
    {
        myImage = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject shortcutObj = GameObject.FindWithTag("Shortcut");

        if (shortcutObj != null)
        {
            BShortcut shortcut = shortcutObj.GetComponent<BShortcut>();

            if (shortcut.ShortcutActive())
            {
                Image shortcutImage = shortcut.GetImgItem();

                // Lógica de intercambio (Swap)
                Sprite temp = myImage.sprite;
                myImage.sprite = shortcutImage.sprite;
                shortcutImage.sprite = temp;

                // Actualizamos los tipos después del intercambio
                shortcut.UpdateType();

                Debug.Log("se cambio el sprite en BSlot");
            }

        }
    }
}
