using UnityEngine;

public class MoveUp : IMove
{
    private Rigidbody2D rb;
    private float force = 150f;

    public MoveUp(Rigidbody2D rb)
    {
        this.rb = rb;
    }

    public void Execute()
    {
        rb.AddForce(Vector2.up * force);
    }
}
