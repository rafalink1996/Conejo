using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyrmIceAttacks : MonoBehaviour
{
    BossWyrm wyrm;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        wyrm = FindObjectOfType<BossWyrm>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wyrm.iceTimer <= 0)
        {
            anim.SetTrigger("Shatter");
            print("Shatter");
        }
    }
    public void Deactivate()
    {
        wyrm.iceTimer = 30f;
        gameObject.SetActive(false);
    }
}
