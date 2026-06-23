using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damageAmount = 10f;
    [SerializeField] private ElementType elementType = ElementType.Ninguno;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Trigger detectado con: {collision.gameObject.name}"); // agregar esto

        if (collision.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            Debug.Log("Sí tiene IDamageable, aplicando daño"); //  agregar esto
            DamageInfo info = new DamageInfo(damageAmount, elementType);
            damageable.TakeDamage(info);
        }
        else
        {
            Debug.Log("NO tiene IDamageable"); //  agregar esto
        }
    }
}