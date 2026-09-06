using UnityEngine;
using System.Collections;

public class Salt : MonoBehaviour, IItem
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip saltSound;

    private Rigidbody2D rb;

    private float speed = 5f;

    private float d;

    private float lifeTime = 3f;
    private Coroutine restartCor;

    private bool inZone;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Item(float direction)
    {
        this.d = direction;

        inZone = false;

        rb.bodyType = RigidbodyType2D.Dynamic;

        // Movimiento en una sola dirección al activarse
        rb.linearVelocity = new Vector2(d * speed, 0f);
        // Audio
        if (audioSource != null && saltSound != null)
            audioSource.PlayOneShot(saltSound);

        restartCor = StartCoroutine(ReturnPool());
    }

    private void OnDisable()
    {
        if (restartCor != null)
        {
            StopCoroutine(restartCor);
            restartCor = null;
        }

        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        inZone = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inZone || !collision.CompareTag("SaltZone"))
            return;

        SaltZone zone = collision.GetComponent<SaltZone>();

        if (zone == null || zone.IsOccupied)
            return;

        inZone = true;
        zone.SetOccupied(true);

        if (restartCor != null)
        {
            StopCoroutine(restartCor);
            restartCor = null;
        }

        transform.position = zone.transform.position;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
    }

    private IEnumerator ReturnPool()
    {
        yield return new WaitForSeconds(lifeTime);

        if (!inZone)
        {
            rb.linearVelocity = Vector2.zero;
            ItemPool.Instance.ReturnToPool("Salt", gameObject);
        }
    }
}
