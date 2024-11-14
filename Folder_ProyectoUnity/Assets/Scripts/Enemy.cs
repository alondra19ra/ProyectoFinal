using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] patrolPoints;  
    public float patrolSpeed = 2f;    
    private int currentPointIndex = 0; 

    private float patrolStartDelay = 10f; 
    private bool isPatrolling = false;    
    private float timer = 0f;            

    void Start()
    {
       
        transform.position = patrolPoints[0].position;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= patrolStartDelay)
        {
            isPatrolling = true;
        }

        if (isPatrolling)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, patrolSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolPoints[currentPointIndex].position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length; 
        }
    }
}

