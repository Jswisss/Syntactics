using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SpellPicker : MonoBehaviour
{
    public Button[] SelectedButtonPrefab;
    public Button[] SpellSelecterButton;

    public GameObject Player;

    public GameObject[] Panels;
    public TextMeshProUGUI SpellSelectedText;
    private int spellsSelected=0;
    public Button confirmbutton;
    public Canvas MainCanvas;


    public void Update()
    {
        SpellSelectedText.text = "Spells Selected " + spellsSelected.ToString() + "/4";

        if(spellsSelected==4)
        {
            confirmbutton.image.color = Color.white;
        }
        else
        {
            confirmbutton.image.color = Color.gray;
        }
    }

    public void spellchoices(string spell)
    {
        if(spellsSelected< 4)
        {
        if (spell == "Fire Ball")
        {
            SelectedButtonPrefab[0].gameObject.SetActive(true);
            SpellSelecterButton[0].gameObject.SetActive(false);
            
        }

        if (spell == "Fire Wall")
        {
            SelectedButtonPrefab[1].gameObject.SetActive(true);
            SpellSelecterButton[1].gameObject.SetActive(false);
        }

        if (spell == "Heal")
        {
            SelectedButtonPrefab[2].gameObject.SetActive(true);
            SpellSelecterButton[2].gameObject.SetActive(false);
        }

        if (spell == "Water Wall")
        {
            SelectedButtonPrefab[3].gameObject.SetActive(true);
            SpellSelecterButton[3].gameObject.SetActive(false);
        }

        if (spell == "Lightning Bolt")
        {
            SelectedButtonPrefab[4].gameObject.SetActive(true);
            SpellSelecterButton[4].gameObject.SetActive(false);
        }

        if (spell == "Lightning Wall")
        {
            SelectedButtonPrefab[5].gameObject.SetActive(true);
            SpellSelecterButton[5].gameObject.SetActive(false);
        }


        if (spell == "Water Blast")
        {
            SelectedButtonPrefab[6].gameObject.SetActive(true);
            SpellSelecterButton[6].gameObject.SetActive(false);
        }
        spellsSelected++;
        }
        
    }


    public void confirmSpells()
    {
        int j = 0;
        if (spellsSelected == 4)
        {
            for (int i = 0; i < 7; i++)
            {
                if (SelectedButtonPrefab[i].IsActive())
                {
                    MainCanvas.GetComponent<SpellListScript>().SpellList[j] = SelectedButtonPrefab[i].GetComponentInChildren<Text>().text.ToLower();
                    //add to list for active commands and add to spell list
                    j++;
                }
            }
            //Panels[0].SetActive(false);
            //Panels[1].SetActive(false);
            //Panels[2].SetActive(false);
            MainCanvas.GetComponentInChildren<SpellListScript>().Spells(MainCanvas.GetComponent<SpellListScript>().SpellList);
            // Player.GetComponent<Magic>().spells = MainCanvas.GetComponent<SpellListScript>().SpellList;
            // Player.GetComponent<Magic>();
            Panels[4].SetActive(false);
            Panels[5].SetActive(true);
            MainCanvas.GetComponentInChildren<TerminalScript>().startingMatch = true;
        }
    }

    public void Back()
    {
        Panels[0].SetActive(true);
        Panels[1].SetActive(false);
        Panels[2].SetActive(false);
    }

    public void Elementals()
    {
        Panels[0].SetActive(false);
        Panels[1].SetActive(false);
        Panels[2].SetActive(true);
    }
    public void Defenses()
    {
        Panels[0].SetActive(false);
        Panels[1].SetActive(true);
        Panels[2].SetActive(false);
    }



    public void spelldeselecter(string spell)
    {
        if (spell == "Fire Ball")
        {

            SelectedButtonPrefab[0].gameObject.SetActive(false);
            SpellSelecterButton[0].gameObject.SetActive(true);
        }

        if (spell == "Fire Wall")
        {
            SelectedButtonPrefab[1].gameObject.SetActive(false);
            SpellSelecterButton[1].gameObject.SetActive(true);
        }

        if (spell == "Heal")
        {
            SelectedButtonPrefab[2].gameObject.SetActive(false);
            SpellSelecterButton[2].gameObject.SetActive(true);
        }

        if (spell == "Water Wall")
        {
            SelectedButtonPrefab[3].gameObject.SetActive(false);
            SpellSelecterButton[3].gameObject.SetActive(true);
        }

        if (spell == "Lighting Bolt")
        {
            SelectedButtonPrefab[4].gameObject.SetActive(false);
            SpellSelecterButton[4].gameObject.SetActive(true);
        }

        if (spell == "Lighting Wall")
        {
            SelectedButtonPrefab[5].gameObject.SetActive(false);
            SpellSelecterButton[5].gameObject.SetActive(true);
        }
        

        if (spell == "Water Blast")
        {
            SelectedButtonPrefab[6].gameObject.SetActive(false);
            SpellSelecterButton[6].gameObject.SetActive(true);
        }
        spellsSelected--;
    }
}
