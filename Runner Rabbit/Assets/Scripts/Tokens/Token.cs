using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour, IPooledObject
{
    [SerializeField] float speed = 5f;
    [SerializeField] Transform PlayerTarget;
    bool canCollide = true;

    float DespawnTime = 8;
    bool despawned;
    float MaxDespawnTime = 8;
    [SerializeField] bool magnetic;
    [SerializeField] int ID;
    bool IsbeingMagnetized;

    float DistanceLastCall;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTarget = GameObject.FindObjectOfType<character>().transform;
    }

    public void OnObjectSpawn()
    {
        IsbeingMagnetized = false;
        DespawnTime = MaxDespawnTime;
        despawned = false;
        canCollide = true;
    }


    void Update()
    {
        if (PlayerTarget != null && magnetic)
        {
            if (GameStats.stats.Rune1 == GameStats.Rune.MagnetRune || GameStats.stats.Rune2 == GameStats.Rune.MagnetRune)
            {
                if (Time.time - DistanceLastCall >= 0.1)
                {
                    float dis = Vector2.Distance(PlayerTarget.position, transform.position);

                    if (dis < 1.5)
                    {
                        // player is within magnet range
                        IsbeingMagnetized = true;
                    }
                    DistanceLastCall = Time.time;
                }
            }
        }
        if (IsbeingMagnetized)
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerTarget.position, 0.5f);
        }
        else
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }


        if (DespawnTime > 0 && !despawned)
        {
            DespawnTime -= Time.deltaTime;
        }
        else
        {
            despawned = true;
            IsbeingMagnetized = false;
            gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player" && canCollide)
        {
            canCollide = false;
            gameObject.SetActive(false);
            IsbeingMagnetized = false;
            if (ID == 2)
            {
                FindObjectOfType<AudioManager>().Play("HeartHeal");
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Coin");
            }

        }
    }


}
