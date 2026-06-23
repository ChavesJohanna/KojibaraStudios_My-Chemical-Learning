using UnityEngine;
using UnityEngine.UI;

public class LBar : MonoBehaviour, IDamage
{
    private Image img;

    private float max = 100f;
    private float amount = 15f;

    private float cur;

    private void Start()
    {
        img = transform.Find("Full").GetComponent<Image>();
        cur = max;
        img.fillAmount = 1f;
    }
    
    // aqui se va restando su imagen
    public void Damage()
    {
        cur = Mathf.Clamp(cur - amount, 30f, max);
        img.fillAmount = cur / max;

        Debug.Log("restando vida");

        if (cur == 30f) Debug.Log("jugador morido");
    }
}
