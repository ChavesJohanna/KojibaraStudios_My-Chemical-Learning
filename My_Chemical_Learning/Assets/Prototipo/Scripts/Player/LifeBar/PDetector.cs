using UnityEngine;
using UnityEngine.SceneManagement;

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
        else if (collision.gameObject.CompareTag("DieZone"))
        {
            SceneManager.LoadScene("GameOver");
            Debug.Log("Jugador morido llendo a pantalla de GameOver");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Victory");
            Debug.Log("Nivel 1 completado");
        }       
    }
}
