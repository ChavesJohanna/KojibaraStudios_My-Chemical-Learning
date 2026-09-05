using UnityEngine;

public class DañarJugador : MonoBehaviour //el script se encuentra en el gameobject "Jugador"
{
    private BarraVida barraVida;

    private void Start()
    {
        barraVida = GameObject.Find("BarraVida").GetComponent<BarraVida>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Pirito")) //si coliciona con el enemigo con tag Pirito le quita vida
        {
            barraVida.Disminuir();

            Debug.Log("colicion con pirito detectada");
        }
    }
    private void OnCollisionEnter2D(Collision2D otro)
    {
        if (otro.gameObject.CompareTag("Fuego"))
        {
            barraVida.Disminuir();
            Debug.Log("colicion con fuego detectada");
        }
    }
}
