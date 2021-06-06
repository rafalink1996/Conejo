using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour, IPooledObject
{
    [SerializeField] float speed = 5f;
    [SerializeField] Transform PlayerTarget;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTarget = GameObject.FindObjectOfType<character>().transform;
    }

    public void OnObjectSpawn()
    {

    }

    
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
        else
        {
            // rune is not active
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("Coin");
        }
    }
}
