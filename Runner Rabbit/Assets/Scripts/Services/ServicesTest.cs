using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CloudOnce;

public class ServicesTest : MonoBehaviour
{
    [SerializeField] Text PoinText;

    private void Start()
    {
        PoinText.text = CloudOnce.CloudVariables.Test.ToString();
    }

    private void Update()
    {
        PoinText.text = CloudOnce.CloudVariables.Test.ToString();
    }

    public void AddPoint()
    {
        CloudOnce.CloudVariables.Test++;
        Cloud.Storage.Save();
    }
}
