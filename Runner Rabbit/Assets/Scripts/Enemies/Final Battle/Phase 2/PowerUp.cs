using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float frequency = 10.0f; // Speed of sine movement
    public float magnitude = 1.0f; //  Size of sine movement, its the amplitude of the side curve
    public float speed = 1.0f;
    Animator anim;
    Vector3 pos;
    Vector3 axis;
    TokenSpawner TKSpawner;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pos = transform.position;
        axis = transform.up;
        StartCoroutine(Destroy());
        TKSpawner  = GameObject.Find("Token Spawner").GetComponent<TokenSpawner>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetTrigger("Activate!");
            StartCoroutine(SpawnShadowMissle());
            speed = -10;
            frequency = 0;
            magnitude = 0;
        }
    }

    void Update()
    {
        pos += Vector3.left * Time.deltaTime * speed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude; // y = A sin(B(x)) , here A is Amplitude, and axis * magnitude is acting as amplitude. Amplitude means the depth of the sin curve
    }

    IEnumerator Destroy()
    {

        yield return new WaitForSeconds(10f);
        TKSpawner.OneDown();
        Destroy(gameObject);
    }

    IEnumerator SpawnShadowMissle()
    {

        yield return new WaitForSeconds(0.2f);
        GameObject shadowArrow = GameObject.Instantiate(Resources.Load("Prefabs/ShadowArrow") as GameObject);
        shadowArrow.transform.position = transform.position;
        Destroy(shadowArrow, 5f);
        yield return new WaitForSeconds(0.3f);
        TKSpawner.OneDown();
        Destroy(gameObject);

    }

}
