using UnityEngine;

public class contenedorSombreroUI : MonoBehaviour
{
    [SerializeField] private VidaUI[] hats;
    private PlayerHealth playerHealth;
    private void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        playerHealth.playerTakesDamage += ActivaSombrero;
        ActivaSombrero(playerHealth.GetCurrentHealth());
    }
    private void OnDisable()
    {
        playerHealth.playerTakesDamage -= ActivaSombrero;
    }

    
    private void ActivaSombrero(int currentHealth)
    {
        for (int i = 0; i < hats.Length; i++)
        {
            if (i < currentHealth)
            {
                if (hats[i].IsActive()) { continue; }
                hats[i].ActiveHat();
            }
            else
            {
                if (!hats[i].IsActive()) { continue; }
                hats[i].DeactiveHat();
            }
        }
       
    }
}
