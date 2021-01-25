using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowHandGroup : MonoBehaviour
{

    public ShadowMageHand [] Hands;
    public int myEnemyCount;
    public EnemySpawner enemySpawner;
    EnemyHealth ShadowMageHealth;
    ShadowMage ShadowMageCS;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimedAttack(Random.Range(1,3)));
        if (transform.position.y > 0)
        {
            enemySpawner = GameObject.Find("Enemy Spawner (Up)").GetComponent<EnemySpawner>();
        }
        if (transform.position.y < 0)
        {
            enemySpawner = GameObject.Find("Enemy Spawner (Down)").GetComponent<EnemySpawner>();
        }
        enemySpawner.SetEnemyCount(myEnemyCount);

        ShadowMageHealth = GameObject.Find("Head shadow").GetComponent<EnemyHealth>();
        ShadowMageCS = GameObject.Find("Head shadow").GetComponent<ShadowMage>();
    }

   

    IEnumerator TimedAttack(int AttackTimes)
    {
        int i= 0;
        while (true)
        {
            if (AttackTimes > 0)
            {
                if (i != Hands.Length)
                {
                    yield return new WaitForSeconds(0.5f);
                    Hands[i].StartAttacking();
                    i++;
                    
                }
                else
                {
                    
                    i = 0;
                    AttackTimes--;
                }
            }
            else
            {
                if (ShadowMageCS.ShieldIsUp != true)
                {
                    ShadowMageHealth.TakeDamage(2);
                }
                
                yield return new WaitForSeconds(1.5f);
                DespawnShadowHands();
                break;
            }
            
            
            
        }
        
        
    }

    void DespawnShadowHands()
    {
        for (int i = 0; i < Hands.Length; i++)
        {
            Hands[i].StartDespawning();
            enemySpawner.OneDown();
            StartCoroutine(DestroyGroup());
        }
        
    }

    IEnumerator DestroyGroup()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
