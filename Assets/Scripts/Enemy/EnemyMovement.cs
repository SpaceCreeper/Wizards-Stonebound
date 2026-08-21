using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public SpriteRenderer spriteRenderer;

    public Transform[] waypoints = new Transform[2];

    public float moveSpeed;
    public float stepSize; //stepDistance or stepLength or moveLength
    public float pauseDurationInSeconds;
    

    [SerializeField, Range(0, 1)] private int currentWaypointIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if (waypoints.Length != 2)
        {
            Debug.LogError("Enemy reference to waypoints is incomplete!");
            return;
        }

        StartCoroutine(PatrolRoutine());
    }
    
    IEnumerator PatrolRoutine()
    {
        while (true)
        {
            Transform targetWaypoint = waypoints[currentWaypointIndex];
            float distanceToWaypoint = Vector2.Distance(rb2d.position, targetWaypoint.position);
            Vector2 direction = ((Vector2)targetWaypoint.position - rb2d.position).normalized;

            // If enemy reached target, swap target, wait and repeat
            if (distanceToWaypoint < 0.05f)
            {
                currentWaypointIndex = (currentWaypointIndex == 0) ? 1 : 0;
                yield return new WaitForSeconds(pauseDurationInSeconds);
                continue;
            }

            spriteRenderer.flipX = direction.x < 0;

            float nextStepLength = Mathf.Min(distanceToWaypoint, stepSize);
            Vector2 nextTargetPosition = rb2d.position + (nextStepLength * direction);

            float slideDurationInSeconds = nextStepLength / moveSpeed;
            Debug.Log(slideDurationInSeconds);

            Vector2 currentPosition = rb2d.position;
            float elapsed = 0f;
            while (elapsed < slideDurationInSeconds)
            {
                float t = elapsed / slideDurationInSeconds;
                rb2d.MovePosition(Vector2.Lerp(currentPosition, nextTargetPosition, t));
                
                elapsed += Time.fixedDeltaTime;

                yield return new WaitForFixedUpdate();
            }

            rb2d.MovePosition(nextTargetPosition);

            yield return new WaitForSeconds(pauseDurationInSeconds);
        }
    }

    public void StartPatrol()
    {
        StopAllCoroutines();

        currentWaypointIndex = Random.Range(0, waypoints.Length); // Random.Range is exclusive upper bound
        
        StartCoroutine(PatrolRoutine());
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(waypoints[0].position + Vector3.up, waypoints[1].position + Vector3.up);
    }
}
