using UnityEngine;

public class MoveLeft : IMove
{
    private Rigidbody2D rb;
    private float speed = -3f;

    public MoveLeft(Rigidbody2D rb)
    {
        this.rb = rb;
    }

    public void Move()
    {
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }
}