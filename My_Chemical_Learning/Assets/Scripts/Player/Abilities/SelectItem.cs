using UnityEngine;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour
{
    public static SelectItem Instance { get; private set; }

    private Image image;

    private string nameI; //nombre del item

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NameImage(Image img)
    {
        if (img == null)
        {
            Debug.Log("NameImage recibió una Image nula.");
            return;
        }

        if (img.sprite == null)
        {
            Debug.Log($"La Image '{img.name}' no tiene sprite asignado.");
            return;
        }

        nameI = img.sprite.name;
    }

    public void RestartName()
    {
        nameI = null;
    }

    public string NameI()
    {
        return nameI;
    }
}
