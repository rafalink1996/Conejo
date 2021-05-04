using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePunch : MonoBehaviour
{
    public character Cha;
    Vector3 pos; 
    // Start is called before the first frame update
    void Start()
    {
        Cha = FindObjectOfType<character>();
        pos = transform.position;
        pos.x = Cha.transform.position.x;
        
        if (!Cha.top && Cha.transform.position.y >= 5)
        {
            pos.y = 7.728f;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (!Cha.top && Cha.transform.position.y <= 5)
        {
            pos.y = 3.78f;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (Cha.top && Cha.transform.position.y >= -5)
        {
            pos.y = -3.78f;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Cha.top && Cha.transform.position.y <= -5)
        {
            pos.y = -7.728f;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void Over()
    {
        Destroy(gameObject);
    }

    void PunchSound()
    {
        FindObjectOfType<AudioManager>().Play("YetiPunch");
    }
}
