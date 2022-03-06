using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TerminalScript : MonoBehaviour
{
    
    public int number= 1;
    public TextMeshProUGUI terminal;
    public float delay = 6;
    public float HealthDisplaydelay = 10;
    public float Ramdelay = 6;
    private bool inBurnOut = false;
    public bool startingMatch = false;
    public bool startMatch = false;
    public GameObject gamecontr;
    //public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        terminal.text = terminal.text + number + "                              Ready Fighters\n";
        number++;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startingMatch == true)
        {
            delay -= Time.deltaTime;
            if (delay <= 5 && delay >= 4.983)
            {

                terminal.text = terminal.text + number + "                                        " + delay.ToString("0") + "\n";
                number++;

            }
            if (delay <= 4 && delay >= 3.983)
            {

                terminal.text = terminal.text + number + "                                        " + delay.ToString("0") + "\n";
                number++;
            }
            if (delay <= 3 && delay >= 2.983)
            {

                terminal.text = terminal.text + number + "                                        " + delay.ToString("0") + "\n";
                number++;
            }
            if (delay <= 2 && delay >= 1.983)
            {

                terminal.text = terminal.text + number + "                                        " + delay.ToString("0") + "\n";
                number++;
            }
            if (delay <= 1 && delay >= 0.983)
            {

                terminal.text = terminal.text + number + "                                        " + delay.ToString("0") + "\n";
                number++;
            }
            if (delay <= 0 && delay >= -0.017)
            {

                terminal.text = terminal.text + number + "                                      " + "Fight\n";
                number++;
                startMatch = true;
            }

            if(startMatch== true)
            {
            HealthDisplaydelay -= Time.deltaTime;
            if (HealthDisplaydelay <= 0 && HealthDisplaydelay >= -.017)
            {
                currenthealth(5, 20);
                HealthDisplaydelay = 10;
            }

            if (inBurnOut == true)
            {
                Ramdelay -= Time.deltaTime;
                if (Ramdelay <= 5 && Ramdelay >= 4.983)
                {

                    terminal.text = terminal.text + number + "     " + Ramdelay.ToString("0") + "\n";
                    number++;

                }
                if (Ramdelay <= 4 && Ramdelay >= 3.983)
                {

                    terminal.text = terminal.text + number + "     " + Ramdelay.ToString("0") + "\n";
                    number++;
                }
                if (Ramdelay <= 3 && Ramdelay >= 2.983)
                {

                    terminal.text = terminal.text + number + "     " + Ramdelay.ToString("0") + "\n";
                    number++;
                }
                if (Ramdelay <= 2 && Ramdelay >= 1.983)
                {

                    terminal.text = terminal.text + number + "     " + Ramdelay.ToString("0") + "\n";
                    number++;
                }
                if (Ramdelay <= 1 && Ramdelay >= 0.983)
                {

                    PlayerInput();
                    inBurnOut = false;
                        Ramdelay = 6;
                }
            }
          }
           
        }
    }

    public void PlayerCast(string spell)
    {
        terminal.text = terminal.text + number + "      User has casted: " + spell + "\n";
        number++;
    }

    public void AICast(string spell)
    {
        terminal.text = terminal.text + number + "      Oppenent has casted: "+ spell + "\n";
        number++;
    }
            
    public void currenthealth(int playerhealth, int AIhealth)
    {
        terminal.text = terminal.text + number + "      User Health is: " + gamecontr.GetComponent<GameController>().playerHealth + ", Oppenent Health is: " + gamecontr.GetComponent<GameController>().bossHealth + "\n";
        number++;
    }
            
    public void PlayerInput()
    {
        terminal.text = terminal.text + number + "      User what do you want to cast? \n";
        number++;
    }

    public void RAMUsage(int used)
    {
        terminal.text = terminal.text + number + "      User's Current RAM usage is: " + gamecontr.GetComponent<GameController>().playerRAM + "/" + 150+ "\n";
    }

    public void InvalidSpell()
    {
        terminal.text = terminal.text + number + "      Invalid Spell Cast has been caught by your system, Please enter a valid spell to cast \n";
        number++;
    }
    public void MaxRam()
    {
        terminal.text = terminal.text + number + "      You have maxed out on your RAM, and are in Burn Out mode you can not cast spell until system coolsdown \n";
        number++;
        inBurnOut = true;
    }
    
    
}
