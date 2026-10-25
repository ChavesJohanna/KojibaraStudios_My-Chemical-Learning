
using UnityEngine;

public class Oxidee : EnemigoMovil
{
    protected override void Start()
    {
        base.Start();

        vida = 20f;
        velocidad = 0.5f;
    }

    protected override System.Collections.IEnumerator AnimacionMuerte()
    {
        animator.SetBool("MorirOxidee", true);

        // Espera a que termine la animación de muerte.
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Acido"))
        {
            RecibirDaño(5f, "Acido");
        }
    }
}
