using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGroup : MonoBehaviour, IPooledObject
{
    [System.Serializable]
    public class TokenPosition
    {
        public Vector3[] coinPositions;
        public Vector3[] crystalPositions;
        int ID;
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
        if(myObjectPooler != null)
        {
            myObjectPooler = ObjectPooler.Instance;
        }
        for(int i = 0; i < tokenPositions.Count; i++)
        {
            for (int coin = 0; coin < tokenPositions[i].coinPositions.Length; coin++)
            {
                GameObject myCoin = myObjectPooler.SpawnFromPool(coinTag, transform.position, Quaternion.identity);
                myCoin.transform.parent = gameObject.transform;
                myCoin.transform.localPosition += tokenPositions[i].coinPositions[coin];
                myCoin.SetActive(true);
            }

            if(tokenPositions[i].crystalPositions.Length != 0)
            {
                for (int k = 0; k < tokenPositions[i].crystalPositions.Length; k++)
                {
                    GameObject myCrystal = myObjectPooler.SpawnFromPool(crystalTip, tokenPositions[i].crystalPositions[k], Quaternion.identity);
                    myCrystal.SetActive(true);
                }
            }
            
        }
    }

    private void Update()
    {
        
    }




}
