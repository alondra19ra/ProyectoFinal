using UnityEngine;
using UnityEngine.InputSystem;

public class NovaController : MonoBehaviour
{

    [Header("Movimiento")]
    public float speed = 5f;            
    public float acceleration = 2f;     
    public bool useMRUV = false;  

    private Rigidbody rb;
    private Vector2 moveInput;
    private float currentSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (!useMRUV)
            currentSpeed = speed;

        else
            currentSpeed += acceleration * Time.deltaTime;
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput=context.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        rb.velocity=new Vector3(moveInput.x, 0, moveInput.y) * speed ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Objects"))
        {
            GameManager.Instance.Add(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}

