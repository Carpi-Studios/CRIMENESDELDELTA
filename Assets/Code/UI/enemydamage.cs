using Unity.VisualScripting;
using UnityEngine;

public class enemydamage : MonoBehaviour
{
    [SerializeField] private int damage;


    private void OnCollisionEnter(Collision collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.takeDamage(damage); 
        }

    }
}
