using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGriffin : MonoBehaviour
{
    public GameObject rayAttack;
    public GameObject silenceTop;
    public GameObject silenceBot;
    public bool bossTop;
    public bool silence;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.transform.position.y > 0)
        {
            bossTop = false;
        }
        else
        {
            bossTop = true;
        }
    }
    void RayAttack()
    {
        rayAttack.SetActive(true);
    }
    void ShootOne()
    {
        GameObject energyBall = Instantiate(Resources.Load("Prefabs/EnergyBall") as GameObject);
        //energyBall.transform.SetParent(transform);
        energyBall.transform.position = transform.position + new Vector3(-1.87f, -0.55f, 0);
        //energyBall.transform.SetParent(null);
        energyBall.transform.rotation = Quaternion.AngleAxis(12.46f, Vector3.forward);
    }
    void ShootTwo()
    {
        GameObject energyBall = Instantiate(Resources.Load("Prefabs/EnergyBall") as GameObject);
        //energyBall.transform.SetParent(transform);
        energyBall.transform.position = transform.position + new Vector3(-2.16f, 0.06f, 0);
        //energyBall.transform.SetParent(null);
        //energyBall.transform.GetChild(0).rotation = Quaternion.AngleAxis(12.46f, Vector3.forward);
    }
    void ShootThree()
    {
        GameObject energyBall = Instantiate(Resources.Load("Prefabs/EnergyBall") as GameObject);
        //energyBall.transform.SetParent(transform);
        energyBall.transform.position = transform.position + new Vector3(-2.21f, 1.2f, 0);
        //energyBall.transform.SetParent(null);
        energyBall.transform.rotation = Quaternion.AngleAxis(-13.678f, Vector3.forward);
    }
    void Silence()
    {
        if (!bossTop)
        {
            silenceTop.SetActive(true);
        }
        else
        {
            silenceBot.SetActive(true);
        }
        silence = true;
        Invoke("DeactivateSilence", 10f);
    }
    void DeactivateSilence()
    {
        silenceTop.SetActive(false);
        silenceBot.SetActive(false);
        silence = false;
    }
}
