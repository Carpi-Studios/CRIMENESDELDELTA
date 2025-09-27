using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    private bool _isOpen = false;
    [SerializeField] private int[] _needItemID;
    [SerializeField] GameObject _body;


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
        _body.transform.Rotate(0, 90, 0);
    }

    private void CloseDoor()
    {
        _body.transform.Rotate(0, -90, 0);
    }
}