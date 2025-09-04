using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    //[SerializeField] private Vector3 _targetRotation = new Vector3(0f, -100f, 0f);
    [SerializeField] private float _rotationSpeed = 3f;

    private bool _isOpen = false;

    public bool CanInteract()
    {
        return true;
    }

    public bool Interact(IInteract interactor)
    {
        _isOpen = !_isOpen;
        // Implementar animaciones o fisicas propias
        Debug.Log("THIS DOOR IS OPEN: " + _isOpen.ToString());
        return true;
    }
}