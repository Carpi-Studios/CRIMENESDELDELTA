using UnityEngine;
public class Interactor : MonoBehaviour, IInteract
{

    /// <summary>
    /// Distance for checking distance for IInteractables <seealso cref="IInteractables"/>
    /// </summary>
    [SerializeField] private float _castDistance = 1.5f;

    /// <summary>
    /// Layer for interactable objects
    /// </summary>
    [SerializeField] private LayerMask interactableLayerMask;

    /// <summary>
    /// Search for an interactive object on an specific LayerMask
    /// </summary>
    /// <returns></returns>

    void Update()
    {
        // Check if the interection button is used 
        if (Input.GetButtonDown("Interact"))
        {
            var interactable = DoInteraction();
            if (interactable != null)
                interactable.Interact(this);
            else
                Debug.Log("NULL IINTERACTABLE");
        }

    }

    public IInteractable DoInteraction()
    {
        IInteractable interactable = null;
        int maxColliders = 5;
        Collider[] hitColliders = new Collider[maxColliders];
        int quantity = Physics.OverlapSphereNonAlloc(transform.position, _castDistance, hitColliders, interactableLayerMask);

        if (quantity > 0)
        {
            foreach (var collider in hitColliders)
            {
                Debug.Log(collider);
                interactable = collider.gameObject.GetComponent<IInteractable>();
                if (interactable != null)
                    return interactable;
            }
        }

        return null;
    }

}