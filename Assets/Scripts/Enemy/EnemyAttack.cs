using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("References")]
    public EnemyMovement enemyMovement;
    public SpriteRenderer spriteRenderer;

    [Header("Detection Settings")]
    public float detectionRadius = 5f;
    public LayerMask playerLayer;
    public LayerMask obstableLayers;

    [Header("Attack Settings")]
    public Spell attackSpell;
    public Transform eyePoint;
    public float bufferSeconds = 0.5f;

    private bool isAttacking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking && DetectPlayer(out Transform playerTransform))
        {
            StartCoroutine(SpellCastRoutine(playerTransform));
        }
    }

    bool DetectPlayer(out Transform playerTransform)
    {
        playerTransform = null;
        
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);
        
        if (!playerCollider) return false;

        // Calculation for direction and distance from the enemy eye to the player for Raycast;
        Vector2 direction = (playerCollider.transform.position - eyePoint.position).normalized;
        float distance = Vector2.Distance(transform.position, playerCollider.transform.position);

        RaycastHit2D wallHit = Physics2D.Raycast(eyePoint.position, direction, distance, obstableLayers);

        if (wallHit) return false;

        playerTransform = playerCollider.gameObject.transform;
        return true;
    }

    IEnumerator SpellCastRoutine(Transform playerTransform)
    {
        isAttacking = true;

        enemyMovement.StopAllCoroutines();

        Vector2 direction = (playerTransform.position - eyePoint.position).normalized;
        spriteRenderer.flipX = direction.x < 0;

        if (attackSpell)
        {
            attackSpell.Cast(eyePoint, (direction.x < 0) ? Vector2.left: Vector2.right, gameObject);
        }
        else
        {
            Debug.LogError($"The enemy {gameObject.name} is missing an Spell reference!");
        }

        yield return new WaitForSeconds(attackSpell.cooldownSeconds);

        isAttacking = false;
        
        enemyMovement.StartPatrol();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellowNice;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
