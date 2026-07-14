using UnityEngine;

public abstract class Spell : ScriptableObject
{
    public enum SpellType { Projectile, Ray, Self }
    public SpellType spellType;

    public string spellName;
    [TextArea(1, 3)] public string description;
    
    public int healthEffect;

    public Sprite icon;

    public float cooldown;

    public abstract void Cast(Transform firePoint, Vector2 direction, GameObject caster=null);
}