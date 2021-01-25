using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 2f;
    public float maxspeed = 10f;
    public float acceleration = 2f;

 
    // Start is called before the first frame update
    void Start()
    {
      if (gameObject.tag == "Enemy" || gameObject.tag == "Enemy proyectile" || gameObject.tag == "House")
        {
            speed = maxspeed;
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (speed < maxspeed)
        {
            speed = speed + acceleration * Time.deltaTime;
        }
        if (speed > maxspeed)
        {
            speed = maxspeed;
        }


        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }
}
