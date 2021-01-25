using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowMageMissle : MonoBehaviour
{

    public float speed= 30;
    private Rigidbody2D rb;
    public float RotateSpeed = 50;
    public int damage;
    public Transform reflectTarget = null;
    Transform PrefabTranform;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        rb = GetComponent<Rigidbody2D>();
        PrefabTranform = GetComponentInParent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 movement = PrefabTranform.rotation * Vector3.left;
        rb.velocity = movement * speed;
    }
}
