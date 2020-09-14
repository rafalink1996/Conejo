using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageGoblin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Attack()
    {
        GameObject fireball = Instantiate(Resources.Load("Prefabs/WyrmFireBall") as GameObject);
        fireball.transform.position = transform.position + new Vector3(-5.5f, -0.1f, 0);
        fireball.GetComponent<WyrmFireBall>().sourceTransform = gameObject.transform;
    }
}
