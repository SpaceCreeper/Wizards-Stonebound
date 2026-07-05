using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSpell", menuName = "ScriptableObject/ProjectileSpell")]
public class ProjectileSpell : Spell
{
    public GameObject projectilePrefab;
    public float projectileSpeed;
    
    public override void Cast(Transform firePoint, Vector2 direction)
    {
        if (projectilePrefab == null) return;

        float angle = Mathf.Atan2(direction.y,  direction.x) * Mathf.Rad2Deg;
        Quaternion spawnRotation = Quaternion.Euler(0, 0, angle);

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, spawnRotation);

        if (projectile.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.linearVelocity = direction * projectileSpeed;
        }

        if (projectile.TryGetComponent<ProjectileImpact>(out var projectileImpact))
        {
            projectileImpact.SetDamage(healthEffect);
        }
    }
}