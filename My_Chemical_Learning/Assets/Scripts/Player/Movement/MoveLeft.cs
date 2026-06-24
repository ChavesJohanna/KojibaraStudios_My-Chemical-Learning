using UnityEngine;

public class MoveLeft : MonoBehaviour, IMove
{
    private float speed = -3f;

    public void Move(Rigidbody2D rigid)
    {
        rigid.linearVelocity = new Vector2(speed, rigid.linearVelocity.y);
    }

}
