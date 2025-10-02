using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    private bool _isOpen = false;
    [SerializeField] private int[] _needItemID;
    [SerializeField] GameObject _body;


    public bool CanInteract(Interactor interactor)
    {
        if (_needItemID.Length == 0) return true;

        var inventario = interactor.gameObject.GetComponent<Inventory>();
        var hasItem = false;
        foreach (var id in _needItemID)
        {
            hasItem = inventario.HasItemID(id);
            if (hasItem) return hasItem;
        }

        return hasItem;
    }

    public bool Interact(Interactor interactor)
    {
        if (!CanInteract(interactor)) return false;

        if (_isOpen) CloseDoor();
        else OpenDoor();

        _isOpen = !_isOpen;
        
        Debug.Log("THIS DOOR IS OPEN: " + _isOpen.ToString());
        return true;
    }

    protected virtual void OpenDoor()
    {
        _body.transform.Rotate(0, 90, 0);
    }

    protected virtual void CloseDoor()
    {
        _body.transform.Rotate(0, -90, 0);
    }
}