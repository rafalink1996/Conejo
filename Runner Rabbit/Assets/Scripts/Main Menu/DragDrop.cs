using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public string draggingTag;
    public Camera cam;
    private Vector3 dis;
    private float posX;
    private float posY;
    private bool touched = false;
    private bool dragging = false;
    private Transform toDrag;
    private Rigidbody toDragRigidbody;
    private Vector3 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
