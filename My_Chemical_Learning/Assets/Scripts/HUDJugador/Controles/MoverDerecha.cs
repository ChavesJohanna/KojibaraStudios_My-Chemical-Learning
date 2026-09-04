using UnityEngine;

public class MoverDerecha : MonoBehaviour, IMover //el script se encuentra en el boton de movimiento a la derecha (en el hud del jugador)
{
    private float velocidad = 4f;

    public void Mover(Rigidbody2D rb)
    { 
        rb.linearVelocity = new Vector2(velocidad, rb.linearVelocity.y);
    }
}
