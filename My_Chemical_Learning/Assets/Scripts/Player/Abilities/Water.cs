using UnityEngine;

public class Water : MonoBehaviour, IItem
{
    private Rigidbody2D rb;

    private float speed = 10f;

    private float d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Execute(float dir)
    {
        d = dir;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speed * d, 0f);
    }
}
