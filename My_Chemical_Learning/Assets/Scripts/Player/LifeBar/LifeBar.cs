using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private Image fullBar;

    private float maxhealth = 100f;
    private float minhealth = 30f;

    private float current = 100f;

    void Start()
    {
        fullBar = transform.Find("Full").GetComponent<Image>();
    }

    public void LowDamage()
    {
        float low = 5f;

        current = Mathf.Clamp(current - low, minhealth, maxhealth);

        fullBar.fillAmount = current / maxhealth;

        Debug.Log("Vida actual: " + current);
    }

}
