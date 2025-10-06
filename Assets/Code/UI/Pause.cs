using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0;


    }

    public void Despausar()
    {
        Time.timeScale = 1;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainMenu");
    }
}
