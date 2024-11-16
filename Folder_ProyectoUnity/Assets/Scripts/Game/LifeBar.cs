using UnityEngine;
using UnityEngine.UI;
public class LifeBar : MonoBehaviour
{
    public NovaController nova;
    private Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        slider.value = nova.life;
    }
}
