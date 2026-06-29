using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour, IItem
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip waterSound;
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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
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

        if (audioSource != null && waterSound != null)
            audioSource.PlayOneShot(waterSound);

        Debug.Log("awa activada");
    }

    void OnDisable()
    {
        if (restartCor != null)
            StopCoroutine(restartCor);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        piritoHealth pirito = other.GetComponent<piritoHealth>();

        if (pirito != null)
        {
            pirito.TakeHit();
            ItemPool.Instance.ReturnToPool("Water", gameObject);
        }
    }
}
