using UnityEngine;
using UnityEngine.InputSystem;
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
    private PlayerControls controls;    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new PlayerControls();

        // Asigna el evento de movimiento
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    void Update()
    {
        // MRU
        if (!useMRUV)
            currentSpeed = speed;

        // MRUV
        else
            currentSpeed += acceleration * Time.deltaTime;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y) * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement); // Aplica el movimiento en MRU o MRUV
    }
}

