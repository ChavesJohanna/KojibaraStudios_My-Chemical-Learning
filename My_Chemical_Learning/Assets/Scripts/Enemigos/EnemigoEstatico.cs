
using UnityEngine;

public class EnemigoEstatico : Enemigo
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Jugador"))
            return;

        DañarJugador();
    }
}
