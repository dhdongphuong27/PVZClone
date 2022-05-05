using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(Wait());
    }
    public void OptionMenu()
    {
        SceneManager.LoadScene("GameOption");
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("MapSelect");
    }
}
