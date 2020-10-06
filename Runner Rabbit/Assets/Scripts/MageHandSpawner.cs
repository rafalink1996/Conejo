using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageHandSpawner : MonoBehaviour
{
    public float spawnTime;
    public bool Currency;
    public int TokenType = 1;
    public float TokenCount = 0;
    public string[] TokenName;
    bool currencies;
    character Cha;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(3f, 6f);
        TokenType = Random.Range(0, TokenName.Length);
        Cha = FindObjectOfType<character>();
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
            GameObject Tokens = Instantiate(Resources.Load("Prefabs/MageHand") as GameObject);
            Tokens.transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(-1f, 5f), transform.position.z);
            //Tokens.transform.position = new Vector2(0, Random.Range(0, 0));




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
        if (Cha.top)
        {
            transform.position = new Vector3(transform.position.x, -5.48f, transform.position.z);

        }
        else
        {
            transform.position = new Vector3(transform.position.x, 5.48f, transform.position.z);

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