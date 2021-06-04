using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class pool
    {

        public bool Parent;
        public string tag;
        public GameObject prefab;
        public int size;
        public bool Instantiate;

        public int LevelID;
        public bool allLevels;
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
            if (pool.Instantiate)
            {
                GameObject myParent;
                if (pool.Parent)
                {
                    GameObject ParentObject = new GameObject();
                    ParentObject.name = pool.tag + " Container";
                    ParentObject.transform.parent = gameObject.transform;
                    ParentObject.transform.localPosition = new Vector3(0, 0, 0);
                    myParent = ParentObject;
                }
                else
                {
                    myParent = null;
                }
                Queue<GameObject> objectPool = new Queue<GameObject>();
                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    if (myParent != null)
                    {
                        obj.transform.parent = myParent.transform;
                    }
                    objectPool.Enqueue(obj);

                }
                poolDictionary.Add(pool.tag, objectPool);
            }

        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, bool Parent = false)
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

        if (Parent)
        {
            IPooledObject pooledObj = ObjectToSpawn.GetComponentInChildren<IPooledObject>();
            if (pooledObj != null)
            {
                pooledObj.OnObjectSpawn();
            }
        }
        else
        {
            IPooledObject pooledObj = ObjectToSpawn.GetComponent<IPooledObject>();
            if (pooledObj != null)
            {
                pooledObj.OnObjectSpawn();
            }

        }


        poolDictionary[tag].Enqueue(ObjectToSpawn);
        return ObjectToSpawn;
    }
}
