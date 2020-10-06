﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{

    public float speed = 5f;
    public int myTokenCount;

    void Start()
    {
        FindObjectOfType<TokenSpawner>().SetTokenCount(myTokenCount);
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Coin");
        }
    }
}
