using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinMenuStore : MonoBehaviour
{
    public Image SkinTopPreview;
    public Image SkinBotPreview;
    public Image selectdisplayimage;


    public Sprite[] SkinIcons;

    public int SelectedSkinID;

    
    // Start is called before the first frame update
    void Start()
    {
        selectdisplayimage.sprite = SkinIcons[SelectedSkinID];

        SkinTopPreview.sprite = SkinIcons[GameStats.stats.topSkinID];
        SkinBotPreview.sprite = SkinIcons[GameStats.stats.botSkinID];
    }

    // Update is called once per frame
    void Update()
    {
        selectdisplayimage.sprite = SkinIcons[SelectedSkinID];

        SkinTopPreview.sprite = SkinIcons[GameStats.stats.topSkinID];
        SkinBotPreview.sprite = SkinIcons[GameStats.stats.botSkinID];
    }

    public void SelectSkin (int SkinID)
	{
        SelectedSkinID = SkinID;
	}


    public void confirmSkinTop ()
    {
        GameStats.stats.topSkinID = SelectedSkinID;

    }

    public void confirmSkinBot()
    {
        GameStats.stats.botSkinID = SelectedSkinID;

    }


}
