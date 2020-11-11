using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceLances : MonoBehaviour
{
    public Transform[] lance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lance[0].position = Vector2.MoveTowards(lance[0].transform.position, new Vector2(lance[0].transform.position.x, 10), 2 * Time.deltaTime);
        lance[1].position = Vector2.MoveTowards(lance[1].transform.position, new Vector2(lance[1].transform.position.x, 8), 2 * Time.deltaTime);
        lance[2].position = Vector2.MoveTowards(lance[2].transform.position, new Vector2(lance[2].transform.position.x, 6), 2 * Time.deltaTime);
        lance[3].position = Vector2.MoveTowards(lance[3].transform.position, new Vector2(lance[3].transform.position.x, 4), 2 * Time.deltaTime);
    }
}
