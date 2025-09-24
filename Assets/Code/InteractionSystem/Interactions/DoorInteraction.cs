using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    private bool _isOpen = false;


    public bool CanInteract()
    {
        return true;
    }

    public bool Interact(IInteract interactor)
    {
        if (_isOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }

        _isOpen = !_isOpen;
        // Implementar animaciones o fisicas propias
        Debug.Log("THIS DOOR IS OPEN: " + _isOpen.ToString());
        return true;
    }

    private void OpenDoor()
    {
        gameObject.transform.parent.Rotate(0, 90, 0);
    }

    private void CloseDoor()
    {
        gameObject.transform.parent.Rotate(0, -90, 0);
    }
}