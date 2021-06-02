﻿using System.Collections;
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
    bool reflected;

    [HideInInspector] public Transform sourceTransform;
    
    
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

        if (!reflected)
        {
            WaveTime += 0.1f;
            pos += Vector3.left * Time.deltaTime * speed;
            transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * localmagnitude; // y = A sin(B(x)) , here A is Amplitude, and axis * magnitude is acting as amplitude. Amplitude means the depth of the sin curve

        }
        else
        {
             transform.Translate(-13 * Time.deltaTime, 0, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.name == "Kick")
        {
            reflected = true;
            speed = 15;
            print("kick");
            if (collision.GetComponent<Kick>().reflect == false)
            {
                transform.rotation = Quaternion.AngleAxis(Random.Range(120, 240), Vector3.forward);
            }
            else
            {
                var offset = 180f;
                Vector3 direction = sourceTransform.position - transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
            }
        }
        if (collision.tag == "Enemy" && reflected)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
            collision.gameObject.GetComponent<EnemyHealth>().Hit = true;
            print("hit " + collision.gameObject.name);
            Destroy(transform.parent.gameObject);
        }
    }
}


