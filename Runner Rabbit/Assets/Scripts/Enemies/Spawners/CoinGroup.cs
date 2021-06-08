using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGroup : MonoBehaviour, IPooledObject
{
    [System.Serializable]
    public class TokenPosition
    {
        public string Name;
        public Vector3[] coinPositions;
        public Vector3[] crystalPositions;
        public int ID;
    }

    public List<TokenPosition> tokenPositions;

    [SerializeField] ObjectPooler myObjectPooler;

    string coinTag = "Coin";
    string crystalTip = "Crystal";

    private void Awake()
    {
        myObjectPooler = ObjectPooler.Instance;
    }
    void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
    }

    public void OnObjectSpawn()
    {
      
        int i = Random.Range(0, tokenPositions.Count);

        for (int coin = 0; coin < tokenPositions[i].coinPositions.Length; coin++)
        {
            GameObject myCoin = myObjectPooler.SpawnFromPool(coinTag, transform.position, Quaternion.identity);
            myCoin.transform.parent = gameObject.transform;
            myCoin.transform.localPosition += tokenPositions[i].coinPositions[coin];
            myCoin.SetActive(true);
        }

        if (tokenPositions[i].crystalPositions.Length != 0)
        {
            for (int k = 0; k < tokenPositions[i].crystalPositions.Length; k++)
            {
                GameObject myCrystal = myObjectPooler.SpawnFromPool(crystalTip, transform.position, Quaternion.identity);
                myCrystal.transform.parent = gameObject.transform;
                myCrystal.transform.localPosition += tokenPositions[i].crystalPositions[k];

                myCrystal.SetActive(true);
            }
        }


    }

    private void Update()
    {

    }




}
