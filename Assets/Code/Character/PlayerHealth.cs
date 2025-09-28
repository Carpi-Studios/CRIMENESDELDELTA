using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Action<int> playerTakesDamage; //Obeservador de vida

    [SerializeField] private int maxHealth;
    [SerializeField] private int currenthealth;
    
  

    private void Awake()
    {
        currenthealth = maxHealth; 
    }
    public void takeDamage(int damage)
    {
       int temporalHealth = currenthealth - damage;
        temporalHealth = Mathf.Clamp(temporalHealth, 0, maxHealth);
        currenthealth = temporalHealth;
        playerTakesDamage?.Invoke(currenthealth);//pregunta en cuanto es la vida

        if (currenthealth <= 0)
        {
            DestroyPlayer();

        }
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject, 3f);
        LoadDefeatScreen();
    }

    public int GetmaxHealth() => maxHealth;
    public int GetCurrentHealth() => currenthealth;

    private void LoadDefeatScreen()//sistema de carga de escenas de derrotas
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "level1_PB") 
        {
            SceneManager.LoadScene("defeatedLevel1");
        }
        else if (currentScene == "Nivel 2")
        {
            SceneManager.LoadScene("defeatedLevel2");
        }
        else if (currentScene == "Nivel 3") 
        {
            SceneManager.LoadScene("defeatedLevel3");
        }
    }
}





