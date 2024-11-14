using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 positionToMove;
   [SerializeField] private float speedMove;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, positionToMove, speedMove * Time.deltaTime);
    }

    public void SetNewPosition(Vector3 newPosition)
    {
        positionToMove = newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Node"))
        {
            SetNewPosition(other.GetComponent<NodeControl>().GetAdjacentNode().transform.position);
        }
    }
}

