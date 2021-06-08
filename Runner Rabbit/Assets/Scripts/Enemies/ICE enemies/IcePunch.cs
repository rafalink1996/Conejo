using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePunch : MonoBehaviour, IPooledObject
{
    public character Cha;
    Vector3 pos;
    // Start is called before the first frame update
    private void Awake()
    {
        Cha = FindObjectOfType<character>();
    }
    void Start()
    {
        Cha = FindObjectOfType<character>();

        //pos = transform.position;
        //pos.x = Cha.transform.position.x;
        
        //if (!Cha.top && Cha.transform.position.y >= 5)
        //{
        //    pos.y = 7.728f;
        //    transform.rotation = Quaternion.Euler(0, 0, 0);
        //}
        //if (!Cha.top && Cha.transform.position.y <= 5)
        //{
        //    pos.y = 3.78f;
        //    transform.rotation = Quaternion.Euler(0, 0, 180);
        //}
        //if (Cha.top && Cha.transform.position.y >= -5)
        //{
        //    pos.y = -3.78f;
        //    transform.rotation = Quaternion.Euler(0, 0, 0);
        //}
        //if (Cha.top && Cha.transform.position.y <= -5)
        //{
        //    pos.y = -7.728f;
        //    transform.rotation = Quaternion.Euler(0, 0, 180);
        //}
        //transform.position = pos;
    }

    public void OnObjectSpawn()
    {
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

    public void Over()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    void PunchSound()
    {
        FindObjectOfType<AudioManager>().Play("YetiPunch");
    }
}
