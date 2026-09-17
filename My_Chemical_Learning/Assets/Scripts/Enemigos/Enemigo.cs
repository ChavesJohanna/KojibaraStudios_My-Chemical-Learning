using System.Collections;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] protected float vida = 10f;
    [SerializeField] protected string debilidad;

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

    protected virtual void Morir()
    {
        StartCoroutine(AnimacionMuerte());
    }

    protected virtual IEnumerator AnimacionMuerte()
    {
        animator.SetBool("MurioPirito", true);

        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);
    }
}