using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSystem : MonoBehaviour
{
    public AnimatorOverrideController[] Skins;
    public character character;



    public int TopHatSkinIDTop;
    public int TopHatSkinIDBot;


    // Start is called before the first frame update
    void Start()
    {
     if (character.top)
        {
            GetComponent<Animator>().runtimeAnimatorController = Skins[TopHatSkinIDTop] as RuntimeAnimatorController;
        } else
        {
            GetComponent<Animator>().runtimeAnimatorController = Skins[TopHatSkinIDBot] as RuntimeAnimatorController;
        }
            

    }

    // Update is called once per frame
    void Update()
    {

        if (character.top)
        {
            GetComponent<Animator>().runtimeAnimatorController = Skins[TopHatSkinIDTop] as RuntimeAnimatorController;
        }
        else
        {
            GetComponent<Animator>().runtimeAnimatorController = Skins[TopHatSkinIDBot] as RuntimeAnimatorController;
        }

    }
}
