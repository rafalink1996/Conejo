using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonAttack : MonoBehaviour
{
    public ParticleSystem part;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        part = GetComponent<ParticleSystem>();
    }
    
    void OnParticleCollision(GameObject other)
    {
        character cha = other.GetComponent<character>();
        if (cha != null)
        {
            if (!cha.hit)
            {
                cha.LoseHealth();
            }
        }
    }
}
