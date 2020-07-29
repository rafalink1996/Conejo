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
        Destroy(gameObject, 20.61f);
        cha = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cha.transform.position; 
    }
}
