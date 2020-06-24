using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StoreStats : MonoBehaviour
{

    public int Health;
    public int NumOfHearts;
    public GameObject[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    public TextMeshProUGUI lightManaNumber;
    public TextMeshProUGUI DarkManaNumber;

    // Start is called before the first frame update
    void Start()
    {
        NumOfHearts = GameStats.stats.numOfHearts;
        Health = NumOfHearts;

    }

    // Update is called once per frame
    void Update()
    {
        lightManaNumber.text = GameStats.stats.totalLightMana.ToString();
        DarkManaNumber.text = GameStats.stats.totalDarkMana.ToString();


        NumOfHearts = GameStats.stats.numOfHearts;
        Health = NumOfHearts;

        if (Health > NumOfHearts)
        {
            Health = NumOfHearts;
        }
        // number of current hearts is established

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Health)
            {
                hearts[i].GetComponent<Animator>().SetBool("Full", true);
            }
            else
            {
                hearts[i].GetComponent<Animator>().SetBool("Full", false);
            }

            // number of max hearts is established

            if (i < NumOfHearts)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }
}

