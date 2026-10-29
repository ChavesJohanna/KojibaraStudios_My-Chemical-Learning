
using System.Collections;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [Header("Características")]
    [SerializeField] protected float vida = 10f;
    [SerializeField] protected string debilidad;

    [Header("Daño al jugador")]
    [SerializeField] protected float dañoJugador = 10f;

    protected Animator animator;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void RecibirDaño(float daño, string elemento)
    {
        if (elemento == debilidad)
        {
            daño *= 2f;
        }

        vida -= daño;

        if (vida <= 0)
        {
            Morir();
        }
    }

    // Busca la barra de vida y aplica el daño configurado en este enemigo.
    protected void DañarJugador()
    {
        BarraVida barraVida = GameObject.Find("BarraVida")?.GetComponent<BarraVida>();

        if (barraVida != null)
        {
            barraVida.Disminuir(dañoJugador);
        }
    }

    protected virtual void Morir()
    {
        AudioManager.Instance.ReproducirMuerteEnemigo();
        StartCoroutine(AnimacionMuerte());
    }

    protected virtual IEnumerator AnimacionMuerte()
    {
        animator.SetBool("MurioPirito", true);

        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);
    }
}
