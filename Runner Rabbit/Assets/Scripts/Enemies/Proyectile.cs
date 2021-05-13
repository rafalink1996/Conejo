using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public bool DestroyP;

    public int Damage = 1;

    private void Start()
    {
        if (DestroyP)
        {
            Destroy(gameObject, 5f);
        }
    }
}
