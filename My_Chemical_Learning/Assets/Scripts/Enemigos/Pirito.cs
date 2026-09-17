using UnityEngine;

public class Pirito : EnemigoMovil
{
    [SerializeField] private float distancia = 10f;

    private Vector2 posicionInicial;

    protected override void Start()
    {
        base.Start();

        posicionInicial = transform.position;
    }

    protected override void Mover()
    {
        if (!HaySueloDelante())
        {
            CambiarDireccion();
            return;
        }

        float nuevaX = rb.position.x +
                       direccion * velocidad * Time.fixedDeltaTime;

        if (nuevaX >= posicionInicial.x + distancia)  // Límite del recorrido
        {
            CambiarDireccion();
            return;
        }

        if (nuevaX <= posicionInicial.x)
        {
            CambiarDireccion();
            return;
        }

        rb.MovePosition(new Vector2(nuevaX, rb.position.y));

        sprite.flipX = direccion < 0;
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Agua"))
        {
            RecibirDaño(5f, "Agua");
        }
    }
}