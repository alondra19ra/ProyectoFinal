using UnityEngine;
abstract public class Items : MonoBehaviour
{
    [SerializeField] protected Sprite sprite;
    public Sprite GetSprite()
    {
        return sprite;
    }
}
