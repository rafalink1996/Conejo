using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWyrm : MonoBehaviour
{
    public int element = 1;
    public int currentElement = 1;
    public GameObject[] portals;
    public bool ice;
    public float iceTimer = 10f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (element == 1)
        {
            portals[0].SetActive(true);
            portals[1].SetActive(false);
            portals[2].SetActive(false);
        }
        if (element == 2 && !ice)
        {
            portals[0].SetActive(false);
            portals[1].SetActive(true);
            portals[2].SetActive(false);
            ice = true;
        }
        if (element == 3)
        {
            portals[0].SetActive(false);
            portals[1].SetActive(false);
            portals[2].SetActive(true);
        }
        if (ice)
        {
            iceTimer -= Time.deltaTime;
        }
        if (iceTimer <= 0)
        {
            ice = false;
            iceTimer = 10f;
        }
        if (Input.GetKeyDown(KeyCode.A)) //for testing
        {
            anim.SetTrigger("Despawn"); //this will trigger the portal change
            
        }
        
    }
    public void ChangeElement()
    {
        
        while (element == currentElement || element == 2 && ice)
        {
            element = Random.Range(1, 4);
        }
        
        currentElement = element;
    }
    public void NewPortal()
    {
        portals[currentElement - 1].GetComponent<Animator>().SetTrigger("Change");
    }
}
