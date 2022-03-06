using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcontrols : MonoBehaviour
{
   public GameController stats;
   public Magic enemyMagic;
   private float startingAttack;


   void Algorithm()
    {
    

    if(stats.bossHealth < 80)
        {
            enemyMagic.command = "fire wall";
        }

    }

    void Start()
    {
        startingAttack = Random.value;

        if(startingAttack <= 0.33)
        {
            for (int i = 0; i < 4; i++)
            {
                enemyMagic.command = "fire ball";
            }
        }

        else if(startingAttack > 0.33 && startingAttack <= 0.66)
        {
            for (int i = 0; i < 4; i++)
            {
                enemyMagic.command = "lightning ball";
            }
        }

        else if(startingAttack > 0.66)
        {
            for (int i = 0; i < 4; i++)
            {
                enemyMagic.command = "water ball";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyMagic.command = "lightning ball";

        if(stats.bossHealth < 10)
        {
            enemyMagic.command = "water wall";
        }
    }
}
