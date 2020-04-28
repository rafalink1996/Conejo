using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4f);
       // transform.position = GameObject.Find("Enemy Spawner").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
