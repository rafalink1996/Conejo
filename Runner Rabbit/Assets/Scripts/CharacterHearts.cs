using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHearts : MonoBehaviour
{

    public int Health;
    public int NumOfHearts;

    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
// can't have more health than max hearts

        if (Health > NumOfHearts)
        {
            Health = NumOfHearts;
        }
// number of current hearts is established

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < Health) {
                hearts[i].sprite = FullHeart;        
            } else
            {
                hearts[i].sprite = EmptyHeart;
            }

// number of max hearts is established

            if(i < NumOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
