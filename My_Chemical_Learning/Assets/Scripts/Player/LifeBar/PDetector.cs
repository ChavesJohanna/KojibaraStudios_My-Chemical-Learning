using UnityEngine;

public class PDetector : MonoBehaviour
{
    private LifeBar lifeBar;

    void Start()
    {
        lifeBar = GameObject.FindWithTag("LifeBar").GetComponent<LifeBar>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lifeBar.LowDamage();
        }
    }
}
