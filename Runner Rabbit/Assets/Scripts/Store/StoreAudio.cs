using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreAudio : MonoBehaviour
{
    [SerializeField] Image myImage;
    AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<Image>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
   void PlaySound()
    {
        myAudioSource.Play();
    }

    void deactivate()
    {
        StartCoroutine(DeactivateTimer());
    }
    IEnumerator DeactivateTimer()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
