using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGriffin : MonoBehaviour
{
    public GameObject rayAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RayAttack()
    {
        rayAttack.SetActive(true);
    }
}
