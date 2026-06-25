using UnityEngine;

public class PAnimation : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private LayerMask ground;

    private float dif = 0.1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        ground = LayerMask.GetMask("Ground", "Plataforma");
    }

    private void Update()
    {
        float moveX = rb.linearVelocity.x;

        animator.SetBool("isMoving", Mathf.Abs(moveX) > dif);

        bool isGrounded =
            Physics2D.Raycast(rb.position, Vector2.down, 1.5f, ground);

        animator.SetBool("isGrounded", isGrounded);

        if (moveX > dif)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveX < -dif)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void ShootAnim() //para activar la animacion de disparo
    {
        animator.SetTrigger("shoot");
    }
}
