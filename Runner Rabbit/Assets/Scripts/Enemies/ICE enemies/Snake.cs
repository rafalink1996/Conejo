using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour, IPooledObject
{
    public float speed = 3f;
    public float deactivateTime;
    public float MaxDeactivateTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        MaxDeactivateTime = 3;
        
    }

    public void OnObjectSpawn()
    {
        FindObjectOfType<AudioManager>().Play("SnakeHiss");
        deactivateTime = MaxDeactivateTime;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;

        if(deactivateTime < 0)
        {
            Deactivate();
        }
        else
        {
            deactivateTime -= Time.deltaTime;
        }
    }
    void Deactivate()
    {
        gameObject.SetActive(false);
    }
    
}
