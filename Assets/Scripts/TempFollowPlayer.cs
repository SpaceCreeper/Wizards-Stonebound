using UnityEngine;

public class TempFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float followSpeed;
    [SerializeField] private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, 0f) + offset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
    }
}
