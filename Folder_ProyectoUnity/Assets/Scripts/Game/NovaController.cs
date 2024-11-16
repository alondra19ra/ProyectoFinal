using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class NovaController : MonoBehaviour
{

    [Header("Movimiento")]
    public float speed = 5f;            
    public float acceleration = 2f;     
    public bool useMRUV = false;
    public int life;

    private Rigidbody rb;
    private Vector2 moveInput;
    private float currentSpeed;

    private bool invulnerable=true;
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
    private void UpdateHealth(int health)
    {
        life += health;
    }
    private void UserShield()
    {
        invulnerable = true;
        StartCoroutine(Invulnerable());
    }
    private void UserSpeed()
    {
        useMRUV = true;
        StartCoroutine(MRUV());
    }
    private IEnumerator Invulnerable()
    {
        yield return new WaitForSeconds(8);
        invulnerable = false;
    }
    private IEnumerator MRUV()
    {
        yield return new WaitForSeconds(8);
        useMRUV = false;
    }
    private void OnEnable()
    {
        Medikit.health += UpdateHealth;
        Shield.shield += UserShield;
        SpeedBooster.Speed += UserSpeed;
    }
    private void OnDisable()
    {
        Medikit.health -= UpdateHealth;
        Shield.shield -= UserShield;
        SpeedBooster.Speed -= UserSpeed;
    }
}

