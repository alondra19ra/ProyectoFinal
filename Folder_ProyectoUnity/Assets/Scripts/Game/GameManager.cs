using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
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
        Medikit medikit = go.GetComponent<Medikit>();
        if (medikit != null)
        {
            currentgameobject.GetComponent<Image>().sprite = medikit.GetSprite();
            currentgameobject.AddComponent<Medikit>();
        }
    }

    public void Containers1(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase);
        if (context.performed)
        {
            ScaleGameobject(inventory.GetAtPosition(0));
        }
    }

    public void Containers2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ScaleGameobject(inventory.GetAtPosition(1));
        }
    }
    public void Containers3(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ScaleGameobject(inventory.GetAtPosition(2));
        }
    }

    public void Containers4(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ScaleGameobject(inventory.GetAtPosition(3));
        }
    }
    public void UserPowerUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(currentgameobject.GetComponent<Medikit>() != null)
            {
                currentgameobject.GetComponent<Medikit>().UserHealth();
                currentgameobject.GetComponent<Image>().sprite = null;
                Destroy(currentgameobject.GetComponent<Medikit>());
            }
        }
    }
    private void ScaleGameobject(GameObject go)
    {
       
        currentgameobject.transform.localScale = InicialScale;
        currentgameobject = go;
        InicialScale = currentgameobject.transform.localScale;
        currentgameobject.transform.localScale = NewScale;   
    }
}
