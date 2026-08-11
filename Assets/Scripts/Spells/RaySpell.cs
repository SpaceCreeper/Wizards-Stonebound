using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "RaySpell", menuName = "ScriptableObject/RaySpell")]
public class RaySpell : Spell
{
    public Color rayColor;
    [Range(0.0f, 1.0f)] public float startWidth;
    [Range(0.0f, 1.0f)] public float endWidth;
    public float maxRange = 10f;
    
    public float holdDuration = 3f;
    public float secondsPerHit = 1f;

    public LayerMask obstacleLayers;
    public LayerMask enemyLayer;
    [SerializeField] private GameObject beamPrefab;
    
    public override void Cast(Transform firePoint, Vector2 direction, GameObject caster)
    {
        GameObject beamInstance = Instantiate(beamPrefab, firePoint);

        if (beamInstance.TryGetComponent<RayInstance>(out var rayInstance))
        {
            rayInstance.Setup(this);
        }
    }
}