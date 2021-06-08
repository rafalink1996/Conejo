using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    [SerializeField] GameObject cha;
    public bool reflect;
    public float deactivateTime = 0.2f;
    public float deactivateMaxTime = 0.2f;
    //GameObject cha;
    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.name = "Kick";
        deactivateMaxTime = 0.2f;
        cha = FindObjectOfType<character>().gameObject;
    }
    void Start()
    {
        gameObject.name = "Kick";
        deactivateMaxTime = 0.2f;
        cha = FindObjectOfType<character>().gameObject;
        //Destroy(gameObject, 0.2f);//20.61
        //Invoke("Deactivate", 0.2f);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.position = cha.transform.position;
        if(deactivateTime < 0)
        {
            Deactivate();
        }
        else
        {
            deactivateTime -= Time.deltaTime;
        }
    }



}
