using UnityEngine;

public class PuertaJefe : MonoBehaviour
{
    private Collider2D col;


    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Jugador"))
        {
            col.isTrigger = false; //volvemos el collider para q el jugador no pase
        }
    }
}
