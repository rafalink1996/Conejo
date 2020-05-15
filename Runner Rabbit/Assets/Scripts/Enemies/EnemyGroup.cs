using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public int myEnemyCount;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<EnemySpawner>().SetEnemyCount(myEnemyCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
