using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPlant : MonoBehaviour
{

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowards(target.position);
    }

    private void RotateTowards(Vector2 target)
    {
        var offset = 180f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}
