using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RaySpell", menuName = "ScriptableObject/RaySpell")]
public class RaySpell : Spell
{
    public GameObject rayPrefab;
    public float projectileSpeed;

    public float maxRange = 10f;
    [SerializeField] private LayerMask hitLayers;
    
    public override void Cast(Transform firePoint, Vector2 direction, GameObject caster)
    {
        //RaycastHit2D hit = Physics2D.Raycast();
        if (rayPrefab == null) return;

        float angle = Mathf.Atan2(direction.y,  direction.x) * Mathf.Rad2Deg;
        Quaternion spawnRotation = Quaternion.Euler(0, 0, angle);

        //Dealing Damage

        //if (projectile.TryGetComponent<ProjectileImpact>(out var projectileImpact))
        //{
        //    projectileImpact.SetDamage(healthEffect);
        //}
    }
}