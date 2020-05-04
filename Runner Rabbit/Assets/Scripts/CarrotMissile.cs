using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotMissile : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0); 
    }
}
