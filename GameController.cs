using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int playerHealth = 100;
    public int playerRAM = 150;
    public int bossHealth = 100;
    public int bossRAM = 150;
    // 2/3 rounds per match. Reset health and RAM after each round
    bool endRound;
    bool endMatch;
    public int playerwonRounds= 0;
    public int BosswonRounds = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((playerHealth <= 0 || bossHealth <= 0) && (BosswonRounds==2 || playerwonRounds==2))
        {
            endMatch = true;
            SceneManager.LoadScene(0);
        }
        if(playerHealth<=0)
        {
            BosswonRounds++;
            playerHealth = 100;
            playerRAM = 150;
            bossHealth = 100;
            bossRAM = 150;
        }
        if(bossHealth <= 0)
        {
            playerwonRounds++;
            playerHealth = 100;
            playerRAM = 150;
            bossHealth = 100;
            bossRAM = 150;
        }
    }

    public void ChangePlayerHealth(int i)
    {
        playerHealth -= i;
    }

    public void ChangePlayerRAM(int i)
    {
        playerRAM -= i;
    }

    public void ChangeBossHealth(int i)
    {
        bossHealth -= i;
    }

    public void ChangeBossRAM(int i)
    {
        bossRAM -= i;
    }
}
