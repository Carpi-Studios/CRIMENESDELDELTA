using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Nivel 1");
    }
    public void SecondLevel()
    {
        SceneManager.LoadScene("Nivel 2");
    }
    public void ThirdLevel()
    {
        SceneManager.LoadScene("Nivel 3");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
        
}
