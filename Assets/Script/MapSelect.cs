using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelect : MonoBehaviour
{
    public void FrontYardDaytime()
    {
        SceneManager.LoadScene("FrontYardDaytime");
    }
    public void FrontYardNighttime()
    {
        SceneManager.LoadScene("FrontYardNighttime");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
