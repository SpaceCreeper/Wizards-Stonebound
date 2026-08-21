using UnityEngine;

public class ProjectileInstance : MonoBehaviour
{
    ProjectileSpell projectileSpellData;
    GameObject caster;

    public void Setup(ProjectileSpell projectileSpellData, GameObject caster)
    {
        this.projectileSpellData = projectileSpellData;
        this.caster = caster;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, projectileSpellData.projectileLifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == caster) return;
        
        if (collision.gameObject.TryGetComponent<Health>(out var health))
        {
            health.ModifyHealth((int)projectileSpellData.healthEffect);
            Destroy(this.gameObject);
            return;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("BOOM GROUND!");
            Destroy(this.gameObject);
        }
    }
}