﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    public float spawnTime;
    public bool Currency;
    public int TokenType = 1;
    public float TokenCount = 0;
    public string[] TokenName;
    bool currencies;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(3f, 6f);
        TokenType = Random.Range(0, TokenName.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (TokenCount <= 0 && currencies)
        {
            spawnTime = Random.Range(3f, 6f);
            TokenType = Random.Range(0, TokenName.Length);
            Currency = false;
            currencies = false;

        }
        if (!Currency)
        {
            spawnTime -= Time.deltaTime;
        }


        if (spawnTime <= 0 && !Currency)
        {
            TokenCount = 1;
            GameObject Tokens = Instantiate(Resources.Load("Prefabs/" + TokenName[TokenType]) as GameObject);
            Tokens.transform.position = transform.position;



            /*if (enemyType == 1)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Firebook") as GameObject);
                enemy.transform.position = transform.position;
                enemyCount = 1;
            }
            if (enemyType == 2)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Slime") as GameObject);
                enemy.transform.position = transform.position;
                enemyCount = 1;
            }
            if (enemyType == 3)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Enemies 3") as GameObject);
                enemy.transform.position = transform.position;
                enemyCount = 3;
            }
            if (enemyType == 4)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Enemies 4") as GameObject);
                enemy.transform.position = transform.position;
                enemyCount = 4;
            }
            if (enemyType == 5)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Enemies 5") as GameObject);
                enemy.transform.position = transform.position;
                enemyCount = 4;
            }
            if (enemyType == 6)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Book (ice)") as GameObject);
                enemy.transform.position = transform.position;
                enemyCount = 1;
            }
            if (enemyType == 7)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Book (Electric)") as GameObject);
                enemy.transform.position = transform.position;
                enemyCount = 1;
            }*/
            Currency = true;
            currencies = true;
        }

    }
    public void SetTokenCount(int count)
    {
        TokenCount = count;
       // print("Token count");
    }

    public void OneDown()
    {
        TokenCount = TokenCount - 1;
    }
}
