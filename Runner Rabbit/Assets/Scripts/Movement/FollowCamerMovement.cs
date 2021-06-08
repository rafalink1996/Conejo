using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamerMovement : MonoBehaviour
{

    [SerializeField] Transform CameraTarget;
    [SerializeField] float offset;

    private void Start()
    {
        offset = transform.position.x;
    }
    void Update()
    {
        
        transform.position = new Vector3(CameraTarget.transform.position.x + 7.4f, transform.position.y);
    }
}
