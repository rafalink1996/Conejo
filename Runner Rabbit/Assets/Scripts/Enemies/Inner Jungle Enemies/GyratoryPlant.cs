using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyratoryPlant : MonoBehaviour
{
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }
}
    

