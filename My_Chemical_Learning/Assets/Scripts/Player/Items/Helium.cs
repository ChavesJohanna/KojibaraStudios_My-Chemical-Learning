using UnityEngine;
using System.Collections;

public class Helium : MonoBehaviour, IItem
{
    private Rigidbody2D rb;
    private float speed = 3f;

    private float d;

    private float force = 10f;

    private float lifeTime = 3f;
    private Coroutine restartCor;
    public void Item(float direction)
    {
        this.d = direction;

        Rigidbody2D rbPlayer = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();

        float forceUp = Mathf.Abs(direction * force);

        if (direction != 0)
        {
            rbPlayer.linearVelocity = new Vector2(rbPlayer.linearVelocity.x, forceUp);
        }

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0f, speed * Mathf.Abs(d));
    }
    private IEnumerator ReturnPool()
    {
        yield return new WaitForSeconds(lifeTime);
        Debug.Log("volviendo al pool");
        ItemPool.Instance.ReturnToPool("Helium", this.gameObject);
    }

    void OnEnable()
    {
        // Iniciamos la cuenta regresiva cada vez que sale
        restartCor = StartCoroutine(ReturnPool());

        Debug.Log("helio activado");
    }

    void OnDisable()
    {
        if (restartCor != null)
            StopCoroutine(restartCor);
    }
}
