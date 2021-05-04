using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSkins : MonoBehaviour
{
    public AnimatorOverrideController[] Skins;
    SkinSystem skinSystem;
    // Start is called before the first frame update
    void Start()
    {
        skinSystem = FindObjectOfType<SkinSystem>();
        GetComponent<Animator>().runtimeAnimatorController = Skins[skinSystem.activeSkin] as RuntimeAnimatorController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
