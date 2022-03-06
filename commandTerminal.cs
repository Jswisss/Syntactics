using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class commandTerminal : MonoBehaviour
{
    public InputField command;
    private string cmd;
    public GameObject player;
    // Magic playerCommands = new Magic();
    public Canvas MainCanvas;
    string[] spells = new string[4];
    int i = 0;

    public void OnSubmit()
    {
        cmd = command.text;
        Debug.Log(cmd);
        //spells[i] = cmd.Split(' ')[i];
        //playerCommands.command = cmd;
        i++;
        command.text = "";
        player.GetComponent<Magic>().Cast(cmd);
    }

    void Start()
    {

    }

    void Update()
    {
        // playerCommands.Parse(spells);
        if (MainCanvas.GetComponent<TerminalScript>().startMatch == true)
        {
            command.gameObject.SetActive(true);
        }
    }
}


