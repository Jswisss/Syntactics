using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellListScript : MonoBehaviour
{
    public string[] SpellList;
    public Text SpellListText;

    public void Spells(string[] Spellslist)
    {
        SpellListText.text = Spellslist[0]+"\n" + Spellslist[1]+ "\n" + Spellslist[2]+ "\n" + Spellslist[3];
    }
}
