using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool pointerDown;
    public UnityEvent OnHoldDown;
    public UnityEvent OnHoldUp;



    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (pointerDown)
        {

            OnHoldDown.Invoke();


        } else

       
        {

            OnHoldUp.Invoke();


        }


    }

    private void Reset()
    {
        pointerDown = false;
    }



}
