using UnityEngine;

public class MoveUp : IMove
{
    private Rigidbody2D rb;
    private float force = 8.5f;

    private LayerMask groundLayer; 

    public MoveUp(Rigidbody2D rb, LayerMask groundLayer)
    {
        this.rb = rb;
        this.groundLayer = groundLayer;
    }

    public void Move()
    {
        bool isGrounded = Physics2D.Raycast( rb.position, Vector2.down, 1.5f, groundLayer ); // raycast que detecta si toca el piso

        Debug.DrawRay(rb.position,Vector2.down * 10f,Color.red );

        if (!isGrounded)
            return;

        rb.linearVelocity = new Vector2( rb.linearVelocity.x, force );
    }
}
