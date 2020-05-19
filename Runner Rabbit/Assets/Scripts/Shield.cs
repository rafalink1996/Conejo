using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    GameObject cha;
    // Start is called before the first frame update
    void Start()
    {
        cha = GameObject.Find("Character");
        Destroy(gameObject, 0.792f); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cha.transform.position;
    }
}
