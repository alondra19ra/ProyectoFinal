using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public float acceleration = 1.5f;
    private Transform playerTransform;
    private Rigidbody rb;
    private float currentSpeed;
    public Transform[] patrolPoints;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;

        currentSpeed += acceleration * Time.fixedDeltaTime;

        Vector3 movement = direction * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
}

