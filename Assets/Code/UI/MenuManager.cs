using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }
    public void SecondLevel()
    {
        SceneManager.LoadScene(4);
    }
    
    public void ThirdLevel()
    {
        SceneManager.LoadScene(5);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void victory()
    {
        SceneManager.LoadScene(1);
    }

}
