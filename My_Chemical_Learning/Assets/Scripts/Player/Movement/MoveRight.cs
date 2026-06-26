using UnityEngine;

public class MoveRight : MonoBehaviour, IMove
{
    private float speed = 4f;

    public void Move(Rigidbody2D rigid)
    {
        rigid.linearVelocity = new Vector2(speed, rigid.linearVelocity.y);
    }

}
