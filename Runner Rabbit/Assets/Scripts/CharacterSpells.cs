using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpells : MonoBehaviour
{
    public character cha;

    public Spell[] AllSpells;
    public Spell[] PlayerSpells;

    private void Start()
    {
        PlayerSpells[0].id = AllSpells[0].id;
        PlayerSpells[0].icon = AllSpells[0].icon;
        PlayerSpells[0].name = AllSpells[0].name;
        PlayerSpells[0].description = AllSpells[0].description;

        PlayerSpells[1].id = AllSpells[1].id;
        PlayerSpells[1].icon = AllSpells[1].icon;
        PlayerSpells[1].name = AllSpells[1].name;
        PlayerSpells[1].description = AllSpells[1].description;


    }

    public void TestSpellLight ()
    {
        usedSpell(PlayerSpells[0].id);
    }

    public void TestSpellDark()
    {
        usedSpell(PlayerSpells[1].id);
    }

    void usedSpell(int id)
    {
        switch (id)
        {
            case 0:
                print("used spell 1");
               //poner el codigo de cada poder
                break;
            case 1:
                print("used spell 2");
                break;
            case 2:
                print("used spell 3");
                break;
            case 3:
                print("used spell 4");
                break;
            case 4:
                print("used spell 5");
                break;

            default:
                print("spell error");
                break;
        }
    }


}
