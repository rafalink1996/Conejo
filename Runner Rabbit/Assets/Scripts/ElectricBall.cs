﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBall : MonoBehaviour
{
    Transform target;
    float speed = 7f;
    float rotateSpeed = 250f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        Destroy(gameObject, 4f);
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > target.transform.position.x)
        {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.right).z;
        rb.angularVelocity = rotateAmount * rotateSpeed;
        rb.velocity = transform.right * -speed;
        }
       
    }
}
