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
                health.ModifyHealth(damageToDeal);
                Destroy(this.gameObject);
            }
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("BOOM GROUND!");
            Destroy(this.gameObject);
        }
    }
}