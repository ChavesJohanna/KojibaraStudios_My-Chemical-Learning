using UnityEngine;

public class MoveUp : MonoBehaviour, IMove
{
    private float force = 8.5f;

    public void Move(Rigidbody2D rigid)
    {
        LayerMask piso = LayerMask.GetMask("Ground", "Plataforma");

        bool isGrounded = Physics2D.Raycast(rigid.position, Vector2.down, 1.5f, piso); // raycast que detecta si toca el piso

        Debug.DrawRay(rigid.position, Vector2.down * 10f, Color.red);

        if (!isGrounded) return;

        rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, force);
    }

}
