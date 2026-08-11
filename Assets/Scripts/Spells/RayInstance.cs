using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayInstance : MonoBehaviour
{
    RaySpell raySpellData;
    LineRenderer lineRenderer;
    Vector2 direction;

    Vector2 originPoint;
    Vector2 endPoint;
    
    [Min(2)] int vertexCount = 25;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Setup(RaySpell raySpellData)
    {
        this.raySpellData = raySpellData;
        
        lineRenderer = GetComponent<LineRenderer>();
        
        lineRenderer.startColor = raySpellData.rayColor;
        lineRenderer.endColor = raySpellData.rayColor;

        lineRenderer.startWidth = raySpellData.startWidth;
        lineRenderer.endWidth = raySpellData.endWidth;

        lineRenderer.positionCount = vertexCount;
        
        Destroy(this.gameObject, raySpellData.holdDuration);
    }

    // Update is called once per frame
    void Update()
    {
        originPoint = transform.position;
        Vector2 mouseWorldPosition = (Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (mouseWorldPosition - originPoint).normalized;

        // Obtaining distance form firePoint to obstacle hit
        RaycastHit2D obstableHit = Physics2D.Raycast(
            originPoint,
            direction,
            raySpellData.maxRange,
            raySpellData.obstacleLayers
        );

        float hitDistance = obstableHit ? obstableHit.distance : raySpellData.maxRange;

        endPoint = originPoint + (direction * hitDistance);

        // Attacking enemies
        RaycastHit2D[] raycastHits = Physics2D.RaycastAll(originPoint, direction, raySpellData.maxRange, raySpellData.enemyLayer);

        foreach (RaycastHit2D hit in raycastHits)
        {
            if (hit.distance <= hitDistance)
            {
                GameObject enemy = hit.collider.gameObject;
                Debug.Log(enemy);
                enemy.GetComponent<Health>().ModifyHealth(raySpellData.healthEffect);
            }
        }
        
        // Updating LineRenderer
        for (int i = 0; i < vertexCount; i++)
        {
            float t = (float)i / (vertexCount - 1);
            Vector2 point = Vector2.Lerp(originPoint, endPoint, t);

            lineRenderer.SetPosition(i, point);
        }

        Vector2 perpendicular = new Vector2(-direction.y, direction.x);
        lineRenderer.material.SetVector("_Perpendicular", perpendicular);
        lineRenderer.material.SetFloat("_Length", hitDistance);
    }
}