using UnityEngine;

public class PAbility : MonoBehaviour
{
    private Rigidbody2D rb;

    private float lastDirectionX = 1f; // sirve para saber hacia donde disparar

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.x > 0.1f)
        {
            lastDirectionX = 1f;
        }

        else if (rb.linearVelocity.x < -0.1f)
        {
            lastDirectionX = -1f;
        }
    }

    public void UseAbility()
    {
        ItemPool.Instance.Position(transform,lastDirectionX);

        Debug.Log("se mado la posision y direccion la pool");
    }
}
