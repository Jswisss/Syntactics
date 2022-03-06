using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public GameController gameController;
    string element = "";
    int mult = 1;
    int dp = 2;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back, 500 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {

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

    public void setDefnse(int dmg)
    {
        this.dp = dp * mult;
    }
}
