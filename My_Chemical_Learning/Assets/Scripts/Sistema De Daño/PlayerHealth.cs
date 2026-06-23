using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    public event Action<float, float> OnHealthChanged; // (current, max)
    public event Action OnDied;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(DamageInfo info)
    {
        if (currentHealth <= 0) return;

        currentHealth = Mathf.Max(currentHealth - info.amount, 0);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        Debug.Log($"Jugador recibió {info.amount} de daño ({info.element}). Vida restante: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    private void Die()
    {
        OnDied?.Invoke();
    }
}