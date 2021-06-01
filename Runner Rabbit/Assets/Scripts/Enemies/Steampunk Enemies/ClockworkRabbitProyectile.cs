using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockworkRabbitProyectile : MonoBehaviour
{

    public float frequency = 4.0f; // Speed of sine movement
    float localmagnitude = 0;
    public float magnitude = 2.0f; //  Size of sine movement, its the amplitude of the side curve
    public float speed = 1.0f;
    float timerTilWave = 0;
    float WaveTime;

    Vector3 pos;
    Vector3 axis;
    // Start is called before the first frame update
    void Start()
    {
        localmagnitude = 0;
        WaveTime = 0;
        // intialization for zigzag parameters
        pos = transform.position;
        axis = transform.up;
        
    }

    // Update is called once per frame
    void Update()
    {
       
            if (localmagnitude < magnitude)
            {
                localmagnitude += 0.1f;
            }

            WaveTime += 0.1f;
            pos += Vector3.left * Time.deltaTime * speed;
            transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * localmagnitude; // y = A sin(B(x)) , here A is Amplitude, and axis * magnitude is acting as amplitude. Amplitude means the depth of the sin curve
            Debug.Log(Time.time);
        
        

    }
}
