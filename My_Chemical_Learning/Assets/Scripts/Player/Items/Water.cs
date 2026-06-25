using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour, IItem
{
    private Rigidbody2D rb;

    private float speed = 10f;

    private float d;

    private float lifeTime = 3f;
    private Coroutine restartCor;

    public void Item(float direction)
    {
        Debug.Log("Awa recibio la direccion");

        this.d = direction;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speed * d, 0f);
    }

    private IEnumerator ReturnPool()
    {
        yield return new WaitForSeconds(lifeTime);
        Debug.Log("volviendo al pool");
        ItemPool.Instance.ReturnToPool("Water", this.gameObject);
    }

    void OnEnable()
    {
        // Iniciamos la cuenta regresiva cada vez que sale
        restartCor = StartCoroutine(ReturnPool());

        Debug.Log("awa activada");
    }

    void OnDisable()
    {
        if (restartCor != null)
            StopCoroutine(restartCor);
    }
}
