using UnityEngine;

public class EnemigoMovil : Enemigo
{
    [SerializeField] protected float velocidad = 1f;

    [Header("Detector de precipicios")]
    [SerializeField] protected Transform detectorSuelo;
    [SerializeField] protected float distanciaHorizontal = 0.3f;
    [SerializeField] protected float distanciaDetector = 0.5f;
    [SerializeField] protected LayerMask capaSuelo;

    protected SpriteRenderer sprite;
    protected Rigidbody2D rb;

    protected int direccion = 1;

    protected override void Start()
    {
        base.Start();

        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        Mover();
    }

    protected virtual void Mover()
    {
        if (!HaySueloDelante())
        {
            CambiarDireccion();
            return;
        }

        float nuevaX = rb.position.x +
                       direccion * velocidad * Time.fixedDeltaTime;

        rb.MovePosition(new Vector2(nuevaX, rb.position.y));

        sprite.flipX = direccion < 0;
    }

    protected bool HaySueloDelante()
    {
        Vector2 origen = new Vector2(
            detectorSuelo.position.x + direccion * distanciaHorizontal,
            detectorSuelo.position.y
        );

        RaycastHit2D hit = Physics2D.Raycast(
            origen,
            Vector2.down,
            distanciaDetector,
            capaSuelo
        );

        return hit.collider != null;
    }

    protected void CambiarDireccion()
    {
        direccion *= -1;

        sprite.flipX = direccion < 0;
    }

    protected virtual void OnDrawGizmosSelected()
    {
        if (detectorSuelo == null)
            return;

        Gizmos.DrawLine(
            detectorSuelo.position,
            detectorSuelo.position + Vector3.down * distanciaDetector
        );
    }
}