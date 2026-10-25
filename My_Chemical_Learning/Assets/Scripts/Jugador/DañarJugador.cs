using UnityEngine;

public class DañarJugador : MonoBehaviour
{
    private BarraVida barraVida;

    private void Start()
    {
        barraVida = GameObject.Find("BarraVida").GetComponent<BarraVida>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Pirito"))
        {
            barraVida.Disminuir();
            Debug.Log("Colisión con Pirito detectada");
        }
    }

    private void OnCollisionEnter2D(Collision2D otro)
    {
        if (otro.gameObject.CompareTag("Fuego"))
        {
            barraVida.Disminuir();
            Debug.Log("Colisión con Fuego detectada");
        }
        else if (otro.gameObject.CompareTag("Oxidee"))
        {
            barraVida.Disminuir();
            Debug.Log("Colisión con Oxidee detectada");
        }
    }
}