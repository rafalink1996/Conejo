using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceLances : MonoBehaviour
{
    public Transform[] lance;
    int lanceAmount;
    float divideTime = 0.2f;
    bool reflected;
    // Start is called before the first frame update
    void Start()
    {
        lanceAmount = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (divideTime >= 0)
        {
            divideTime -= Time.deltaTime;
        }
        if (divideTime <= 0 && !reflected)
        {
            if (lanceAmount == 1)
            {
                //lance[0].localPosition = Vector2.MoveTowards(lance[0].transform.localPosition, new Vector2(lance[0].transform.localPosition.x, 1.5f), 4 * Time.deltaTime);
                lance[1].gameObject.SetActive(false);
                lance[2].gameObject.SetActive(false);
                lance[3].gameObject.SetActive(false);
            }
            if (lanceAmount == 2)
            {
                lance[0].localPosition = Vector2.MoveTowards(lance[0].transform.localPosition, new Vector2(lance[0].transform.localPosition.x, 1.5f), 4 * Time.deltaTime);
                lance[1].localPosition = Vector2.MoveTowards(lance[1].transform.localPosition, new Vector2(lance[1].transform.localPosition.x, -1.5f), 4 * Time.deltaTime);
                lance[2].gameObject.SetActive(false);
                lance[3].gameObject.SetActive(false);
            }
            if (lanceAmount == 3)
            {
                lance[0].localPosition = Vector2.MoveTowards(lance[0].transform.localPosition, new Vector2(lance[0].transform.localPosition.x, 2.5f), 4 * Time.deltaTime);
                //lance[1].localPosition = Vector2.MoveTowards(lance[1].transform.localPosition, new Vector2(lance[1].transform.localPosition.x, 1.5f), 4 * Time.deltaTime);
                lance[2].localPosition = Vector2.MoveTowards(lance[2].transform.localPosition, new Vector2(lance[2].transform.localPosition.x, -2.5f), 4 * Time.deltaTime);
                lance[3].gameObject.SetActive(false);
            }
            if (lanceAmount == 4)
            {
                lance[0].localPosition = Vector2.MoveTowards(lance[0].transform.localPosition, new Vector2(lance[0].transform.localPosition.x, 4), 4 * Time.deltaTime);
                lance[1].localPosition = Vector2.MoveTowards(lance[1].transform.localPosition, new Vector2(lance[1].transform.localPosition.x, 1.5f), 4 * Time.deltaTime);
                lance[2].localPosition = Vector2.MoveTowards(lance[2].transform.localPosition, new Vector2(lance[2].transform.localPosition.x, -1.5f), 4 * Time.deltaTime);
                lance[3].localPosition = Vector2.MoveTowards(lance[3].transform.localPosition, new Vector2(lance[3].transform.localPosition.x, -4), 4 * Time.deltaTime);
            }
        }
        if (lance[0].GetComponent<IceLance>().reflected || lance[1].GetComponent<IceLance>().reflected || lance[2].GetComponent<IceLance>().reflected || lance[3].GetComponent<IceLance>().reflected)
        {
            reflected = true;
        }
    }
}
