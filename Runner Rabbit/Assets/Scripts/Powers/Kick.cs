using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    public bool reflect;
    //GameObject cha;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 0.2f);//20.61
        Invoke("Deactivate", 0.2f);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
   
}
