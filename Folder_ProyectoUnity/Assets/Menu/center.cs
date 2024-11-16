using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewBehaviourScript : MonoBehaviour
{
    public Ease curve;
    public float velocity;
    RectTransform rectTransform;
    private void Start()
    {
        RectTransform recTransform = GetComponent<RectTransform>();
        recTransform.DOAnchorPos(Vector2.zero, velocity).SetEase(curve);
    }
}
