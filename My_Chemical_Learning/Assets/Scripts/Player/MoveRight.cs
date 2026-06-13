using UnityEngine;

public class MoveRight : IMove
{
    private Rigidbody2D rb;
    private float speed = 3f;

    public MoveRight(Rigidbody2D rb)
    {
        this.rb = rb;
    }

    public void Execute()
    {
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }
}
