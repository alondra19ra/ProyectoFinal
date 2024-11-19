using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float amplitude = 2f; 
    public float frequency = 1f; 
    public float rotationSpeed = 50f; 

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPosition + new Vector3(0, y, 0);

        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
