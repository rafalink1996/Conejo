using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
  

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "character proyectile")
        {
            Destroy(collision.gameObject);
        }
    }
}
