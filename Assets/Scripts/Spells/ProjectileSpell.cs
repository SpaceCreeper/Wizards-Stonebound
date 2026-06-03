using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSpell", menuName = "ScriptableObject/ProjectileSpell")]
public class ProjectileSpell : Spell
{
    public GameObject projectilePrefab;
    public float projectileSpeed;
    
    public override void Cast()
    {
        throw new System.NotImplementedException();
    }
}