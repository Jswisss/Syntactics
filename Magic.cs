using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Magic : MonoBehaviour
{
    /*
     * commandTerminal.cs sends an array of command line strings here to Magic.cs
     * Magic.cs parses each string, saving each command
     * Offense/Defense have two tokens: string element and int mult
     * Parse the command and get those two tokens
     * Heal just heals
     */
    public string command = "";

    public GameObject projectile;
    public GameObject fireProjectile;
    public GameObject waterProjectile;
    public GameObject lightningProjectile;
    public Transform projectileSpawn;
    public GameObject target;
    public GameObject shield;
    public GameObject fireShield;
    public GameObject waterShield;
    public GameObject lightningShield;
    public Transform shieldSpawn;
    public Canvas MainCanvas;

    string[] elementTypes = { "fire", "water", "lightning" };
    string[] elements;
    int[] multAmts = { 1, 2, 3, 4, 5 };
    string[] multsStr;
    int[] mults;
    int dmg = 2;
    int dp = 2;
    bool fire = true;

    private GameController gameController;

    string foundation = "fire ball 1";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Cast(command);
        }
        */
        // Cast(MainCanvas.GetComponent<TerminalScript>().terminal.text);
    }

    public void Cast(string spell)
    {
        string[] spellParts = spell.Split(' ');
        if (isOffense(spell))
        {
            Attack(spell);
        }
        else if (isDefense(spell))
        {
            Defend(spell);
        }
        else if (isHeal(spell))
        {
            Heal(spell);
        }

        else
        {
            MainCanvas.GetComponent<TerminalScript>().InvalidSpell();
        }
    }

    bool isOffense(string spell)
    {
        string[] s = spell.Split(' ');
        return (s[1] == "ball" || s[1] == "blast" || s[1] == "bolt");
    }

    bool isDefense(string spell)
    {
        string[] s = spell.Split(' ');
        return s[1] == "wall";
    }

    bool isHeal(string spell)
    {
        return spell == "heal";
    }
    
    void Attack (string spell)    // Offensive command that shoots projectiles of differnet elements
    {
        string[] s = spell.Split(' ');
        int mult;
        var isNumeric = int.TryParse(s[s.Length - 1], out mult);
        switch (s[0])
        {
            case "fire":
                Instantiate(fireProjectile, projectileSpawn.position, projectileSpawn.rotation);
                fireProjectile.GetComponent<ProjectileScript>().setElement(s[0]);
                fireProjectile.GetComponent<ProjectileScript>().setMultiplier(mult);
                fireProjectile.GetComponent<ProjectileScript>().setDamage(dmg);
                fireProjectile.GetComponent<ProjectileScript>().setTarget(target);
                fireShield.SetActive(false);
                waterShield.SetActive(false);
                lightningShield.SetActive(false);
                MainCanvas.GetComponent<TerminalScript>().PlayerCast(spell);
                break;
            case "water":
                Instantiate(waterProjectile, projectileSpawn.position, projectileSpawn.rotation);
                waterProjectile.GetComponent<ProjectileScript>().setElement(s[0]);
                waterProjectile.GetComponent<ProjectileScript>().setMultiplier(mult);
                waterProjectile.GetComponent<ProjectileScript>().setDamage(dmg);
                waterProjectile.GetComponent<ProjectileScript>().setTarget(target);
                fireShield.SetActive(false);
                waterShield.SetActive(false);
                lightningShield.SetActive(false);
                MainCanvas.GetComponent<TerminalScript>().PlayerCast(spell);
                break;
            case "lightning":
                Instantiate(lightningProjectile, projectileSpawn.position, projectileSpawn.rotation);
                lightningProjectile.GetComponent<ProjectileScript>().setElement(s[0]);
                lightningProjectile.GetComponent<ProjectileScript>().setMultiplier(mult);
                lightningProjectile.GetComponent<ProjectileScript>().setDamage(dmg);
                lightningProjectile.GetComponent<ProjectileScript>().setTarget(target);
                fireShield.SetActive(false);
                waterShield.SetActive(false);
                lightningShield.SetActive(false);
                MainCanvas.GetComponent<TerminalScript>().PlayerCast(spell);
                break;
            default:
                MainCanvas.GetComponent<TerminalScript>().InvalidSpell();
                break;

        }
    }

    void Defend(string spell)
    {
        string[] s = spell.Split(' ');
        switch (s[0])
        {
            case "fire":
                fireShield.BroadcastMessage("setElement", s[0]);
                fireShield.BroadcastMessage("setMultiplier", s[s.Length - 1]);
                fireShield.BroadcastMessage("setDefense", dp);
                fireShield.SetActive(true);
                waterShield.SetActive(false);
                lightningShield.SetActive(false);
                MainCanvas.GetComponent<TerminalScript>().PlayerCast(spell);
                break;
            case "water":
                waterShield.BroadcastMessage("setElement", s[0]);
                waterShield.BroadcastMessage("setMultiplier", s[s.Length - 1]);
                waterShield.BroadcastMessage("setDefense", dp);
                fireShield.SetActive(false);
                waterShield.SetActive(true);
                lightningShield.SetActive(false);
                MainCanvas.GetComponent<TerminalScript>().PlayerCast(spell);
                break;
            case "lightning":
                lightningShield.BroadcastMessage("setElement", s[0]);
                lightningShield.BroadcastMessage("setMultiplier", s[s.Length - 1]);
                lightningShield.BroadcastMessage("setDefense", dp);
                fireShield.SetActive(false);
                waterShield.SetActive(false);
                lightningShield.SetActive(true);
                MainCanvas.GetComponent<TerminalScript>().PlayerCast(spell);
                break;
            default:
                MainCanvas.GetComponent<TerminalScript>().InvalidSpell();
                break;

        }
    }

    void Heal(string spell) // Heal 50 hp for 20 RAM with 10-sec delay
    {
        string[] s = spell.Split(' ');

        MainCanvas.GetComponent<TerminalScript>().PlayerCast(spell);
    }


}
