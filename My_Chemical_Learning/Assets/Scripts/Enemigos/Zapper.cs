using UnityEngine;

public class Zapper : EnemigoEstatico
{
    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Jugador"))
        {
            if (!OxAlum.JugadorProtegido)
            {
                AudioManager.Instance.ReproducirContactoZapper();
                DañarJugador();
            }
        }
    }
}