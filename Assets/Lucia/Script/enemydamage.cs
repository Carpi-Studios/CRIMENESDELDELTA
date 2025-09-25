using Unity.VisualScripting;
using UnityEngine;

public class enemydamage : MonoBehaviour
{
    [SerializeField] private int damage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.takeDamage(damage);
        }
    }
}
