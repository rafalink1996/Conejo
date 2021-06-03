using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class pool
    {
        public GameObject Parent;
        public string tag;
        public GameObject prefab;
        public int size;
    }

    //singelton Pattern
   

    public List<pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    #region singleton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion


    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0;  i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                if (pool.Parent != null)
                {
                    obj.transform.parent = pool.Parent.transform;
                }
                objectPool.Enqueue(obj);
               
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpwanFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("pool With Tag: " + tag + " doesn't exist");
            return null;
        }
        GameObject ObjectToSpawn = poolDictionary[tag].Dequeue();
        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position = position;
        ObjectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObj = ObjectToSpawn.GetComponent<IPooledObject>();
        if(pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(ObjectToSpawn);
        return ObjectToSpawn;
    }
}
