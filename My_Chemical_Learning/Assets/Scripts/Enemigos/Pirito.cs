using UnityEngine;

public class Pirito : EnemigoMovil
{
    protected override void Start()
    {
        base.Start();

        vida = 10f;
        velocidad = 1f;
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Agua"))
        {
            RecibirDaño(5f, "Agua");
        }
    }
}