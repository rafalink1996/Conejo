using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockworkRabbitProyectile : MonoBehaviour
{

    public float frequency = 10.0f; // Speed of sine movement
    public float magnitude = 1.0f; //  Size of sine movement, its the amplitude of the side curve
    public float speed = 1.0f;

    Vector3 pos;
    Vector3 axis;
    // Start is called before the first frame update
    void Start()
    {
        // intialization for zigzag parameters
        pos = transform.position;
        axis = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        pos += Vector3.left * Time.deltaTime * speed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude; // y = A sin(B(x)) , here A is Amplitude, and axis * magnitude is acting as amplitude. Amplitude means the depth of the sin curve
    }
}
