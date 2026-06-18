using UnityEngine;
using UnityEngine.UI;

public class SwapItem : MonoBehaviour
{
    public static SwapItem Instance { get; private set; }

    private Image firstImage;

    private float timer;
    private float deselectTime = 3f;

    private bool isWaiting;

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

    private void Update()
    {
        if (!isWaiting) return;
        
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            firstImage = null;
            isWaiting = false;
        }
    }

    public void SelectImage(Image image)
    {
        if (firstImage == null)
        {
            firstImage = image;

            timer = deselectTime;
            isWaiting = true;

            return;
        }

        if (firstImage == image)
        {
            firstImage = null;
            isWaiting = false;

            return;
        }

        Sprite temp = firstImage.sprite;

        firstImage.sprite = image.sprite;
        image.sprite = temp;

        firstImage = null;
        isWaiting = false;
    }
}
