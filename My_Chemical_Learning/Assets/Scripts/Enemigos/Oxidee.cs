using UnityEngine;

public class Oxidee : EnemigoMovil
{
    protected override void Start()
    {
        base.Start();

        vida = 20f;
        velocidad = 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Acido"))
        {
            RecibirDaño(5f, "Acido");
        }
    }
}