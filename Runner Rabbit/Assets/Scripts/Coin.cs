using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public float speed = 5f;
    public int myTokenCount;
    public Transform PlayerTarget;
   

    void Start()
    {
        FindObjectOfType<TokenSpawner>().SetTokenCount(myTokenCount);
        Destroy(gameObject, 10f);
        if (FindObjectOfType<character>() != null)
        {
            PlayerTarget = GameObject.FindObjectOfType<character>().transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTarget != null)
        {
            if (GameStats.stats.Rune1 == GameStats.Rune.MagnetRune || GameStats.stats.Rune2 == GameStats.Rune.MagnetRune)
            {
                // rune is active
                float dis = Vector2.Distance(PlayerTarget.position, transform.position);

                if (dis < 2)
                {
                    // player is within magnet range
                    float step = 0.5f;
                    transform.position = Vector3.MoveTowards(transform.position, PlayerTarget.position, step);
                }
                else
                {
                    //player si not within magnet range
                    Vector3 temp = transform.position;
                    temp.x += speed * Time.deltaTime;
                    transform.position = temp;
                }
            }
            else
            {
                // rune is not active
                Vector3 temp = transform.position;
                temp.x += speed * Time.deltaTime;
                transform.position = temp;
            }
        }
        
       

        
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