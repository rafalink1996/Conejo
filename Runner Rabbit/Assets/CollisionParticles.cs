using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParticles : MonoBehaviour, IPooledObject
{
    ParticleSystem myParticleSystem;
    float maxDeactivateTime = 3;
    float Deactivatetime;

    private void Awake()
    {
        maxDeactivateTime = 3;
        myParticleSystem = GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        maxDeactivateTime = 3;
        myParticleSystem = GetComponent<ParticleSystem>();
    }

    public void OnObjectSpawn()
    {
        Deactivatetime = maxDeactivateTime;
        myParticleSystem.Play();
    }
    private void Update()
    {
        if(Deactivatetime < 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Deactivatetime -= Time.deltaTime;
        }
    }
}
