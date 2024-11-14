using UnityEngine;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    SimpleLinkList<GameObject> inventory;
    public static GameManager Instance;
    public GameObject[] containers;
    private GameObject currentgameobject;
    private Vector3 InicialScale;
    [SerializeField] private Vector3 NewScale;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        inventory = new SimpleLinkList<GameObject>();
        for (int i = 0; i < containers.Length; i++)
        {
            inventory.InsertAtEnd(containers[i]);
        }
        currentgameobject = containers[0];
        InicialScale = currentgameobject.transform.localScale;
    }

    public void Add(GameObject go)
    {

    }

    public void Containers1(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase);
        if (context.performed)
        {
            CurrentGameobject(inventory.GetAtPosition(0));
        }
    }

    public void Containers2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CurrentGameobject(inventory.GetAtPosition(1));
        }
    }
    public void Containers3(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CurrentGameobject(inventory.GetAtPosition(2));
        }
    }

    public void Containers4(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CurrentGameobject(inventory.GetAtPosition(3));
        }
    }
    private void CurrentGameobject(GameObject go)
    {
       
        currentgameobject.transform.localScale = InicialScale;
        currentgameobject = go;
        InicialScale = currentgameobject.transform.localScale;
        currentgameobject.transform.localScale = NewScale;   
        
    }
}
