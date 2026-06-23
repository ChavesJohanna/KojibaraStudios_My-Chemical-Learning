using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class ElementModifier
{
    public ElementType element;
    [Tooltip("1 = daño normal, 2 = doble daño (debilidad), 0 = inmune")]
    public float multiplicador = 1f;
}

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 50f;
    [SerializeField] private List<ElementModifier> resistencias = new List<ElementModifier>();
    [SerializeField] private float multiplicadorPorDefecto = 1f; // si el elemento no está en la lista

    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(DamageInfo info)
    {
        if (currentHealth <= 0) return;

        ElementModifier modificador = resistencias.FirstOrDefault(r => r.element == info.element);
        float multiplicador = modificador != null ? modificador.multiplicador : multiplicadorPorDefecto;

        float dañoFinal = info.amount * multiplicador;
        currentHealth -= dañoFinal;

        Debug.Log($"{gameObject.name} recibió {dañoFinal} de daño ({info.element}). Vida restante: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}