using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    public bool reflect;
    GameObject cha;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.2f);//20.61
        cha = GameObject.FindObjectOfType<character>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cha.transform.position; 
    }
}
