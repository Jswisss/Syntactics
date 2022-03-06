using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject target;
    public GameObject explosion;
    public GameController gameController;
    string element = "";
    int mult = 1;
    int dmg = 2;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Make projectile move towards target
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {   // Projectile sends a message to Boss cube to tell the GameController to change health
            // Projectile -> Target object (Player to Boss/Boss to Player) -> Send info to GameController   
            if (target.gameObject.tag == "Player")
            {
                gameController.ChangePlayerHealth(dmg);
            }
            else if (target.gameObject.tag == "Target")
            {
                gameController.ChangeBossHealth(dmg);
            }
            Destroy(gameObject);
        }
    }

    public void setElement(string element)
    {
        this.element = element;
    }

    public void setMultiplier(int mult)
    {
        this.mult = mult;
    }

    public void setDamage(int dmg)
    {
        this.dmg = dmg * mult;
    }

    public void setTarget(GameObject target)
    {
        this.target = target;
    }
}
