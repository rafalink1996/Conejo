using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lightpower : MonoBehaviour
{
    private character Cha;
    Button button;


    // Start is called before the first frame update
    void Start()
    {
        Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cha.top == true)
        {
            button.interactable = false;
            transform.SetSiblingIndex(0);
        }
        else
        {
            button.interactable = true;
            transform.SetSiblingIndex(1);
        }


    }
}
