using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenuscript : MonoBehaviour
{
    public GameObject[] Panels;
    public void Battlescene()
    {
        SceneManager.LoadScene(1);
    }

    public void HowToPLay()
    {
        Panels[0].SetActive(false);
        Panels[1].SetActive(true);
    }
    public void exit()
    {
        Application.Quit();
    }

    public void backtoMain()
    {
        Panels[0].SetActive(true);
        Panels[1].SetActive(false);
    }

}
