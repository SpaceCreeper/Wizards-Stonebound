using UnityEngine;

public class ProjectileImpact : MonoBehaviour
{
    public int damageToDeal;

    public void SetDamage(int damageValue)
    {
        damageToDeal = (int)damageValue;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) 
        {
            if (collision.gameObject.TryGetComponent<Health>(out var health))
            {
                health.TakeDamage(damageToDeal);
            }
        }
    }
}