using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public Transform[] views;
    public float transitionSpeed;
    Transform currentView;

    public character Cha;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Cha.top == true)
        {
            currentView = views[1];
        }
        if (Cha.top == false)
        {
            currentView = views[0];
        }

    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
    }
}
