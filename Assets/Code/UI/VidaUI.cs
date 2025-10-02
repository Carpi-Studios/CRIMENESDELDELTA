using UnityEngine;
using UnityEngine.UI;

public class VidaUI : MonoBehaviour
{
    [SerializeField] private Image imagenSombrero;
    [SerializeField] private bool isActive;

    public void ActiveHat()
    {
        imagenSombrero.enabled = true;
        isActive = true;
    }
    public void DeactiveHat()
    {
        imagenSombrero.enabled = false;
        isActive = false;
    }
    public bool IsActive() => isActive;
}
