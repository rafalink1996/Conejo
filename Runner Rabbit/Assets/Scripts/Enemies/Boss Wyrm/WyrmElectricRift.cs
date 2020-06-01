using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyrmElectricRift : MonoBehaviour
{
    public Animator wyrmAnim;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 7f;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            DeactivateThunder();
        }
    }
    public void DeactivateThunder()
    {
        wyrmAnim.SetBool("Thunder", false);
        timer = 7f;
        gameObject.SetActive(false);


    }
}
