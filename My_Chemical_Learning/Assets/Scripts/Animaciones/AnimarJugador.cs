using UnityEngine;

public class AnimarJugador : MonoBehaviour
{
    private Animator animator; //componente que contiene el controlador de las animaciones
    private SpriteRenderer sprite; //sirve para voltear el sprite en modo espejo cuando vaya en otra direccion
    private Rigidbody2D rb;

    private LayerMask piso; //layer del piso para animar el salto

    private float dif = 0.1f; //direrencia de posicion para empezar la animacion

    private void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        piso = LayerMask.GetMask("Piso"); //el nombre del Layer en que se encuntran las plataformas
    }
    private void FixedUpdate()
    {
        float moverX = rb.linearVelocity.x;

        animator.SetBool("Corriendo", Mathf.Abs(moverX) > dif); //animacion de correr si su movimiento en x no es cero

        bool enPiso =
            Physics2D.Raycast(rb.position, Vector2.down, 1.5f, piso); //raycast que detecta si esta tocando el piso

        animator.SetBool("Saltando", !enPiso); //nada un ! no arregle

        if (moverX > dif) //voltea el sprite segun la direccion del movimiento
        {
            sprite.flipX = false;
        }
        else if (moverX < -dif)
        {
            sprite.flipX = true;
        }
    }

    public void AnimarDisparo() //para activar la animacion de disparo
    {
        animator.SetTrigger("Disparando");
    }
}
