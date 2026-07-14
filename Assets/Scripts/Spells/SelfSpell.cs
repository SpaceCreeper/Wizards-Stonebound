using UnityEngine;

[CreateAssetMenu(fileName = "SelfSpell", menuName = "ScriptableObject/SelfSpell")]
public class SelfSpell : Spell
{
    public override void Cast(Transform firePoint, Vector2 direction, GameObject caster)
    {
        caster.GetComponent<Health>().ModifyHealth(healthEffect);
    }
}