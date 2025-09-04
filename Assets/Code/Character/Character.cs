using UnityEngine;

public class Character : MonoBehaviour, IInteract
{
    private CharacterController _char_controles;
    private Vector3 _movement;
    [SerializeField] private float _move_speed = 5.0f;


    [SerializeField] private float _castDistance = 5f;
    [SerializeField] private Vector3 _raycastOffset = Vector3.up;


    void Start()
    {
        _char_controles = GetComponent<CharacterController>();
    }

    void Update()
    {
        _movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * _move_speed;
        _char_controles.SimpleMove(_movement);

        if (Input.GetButtonDown("Interact"))
        {
            if (DoInteraction(out IInteractable interactable))
            {
                interactable.Interact(this);
            }
        }

    }



    public bool DoInteraction(out IInteractable interactable)
    {
        interactable = null;

        Ray ray = new(transform.position + _raycastOffset, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _castDistance))
        {
            interactable = hitInfo.collider.GetComponent<IInteractable>();
        }

        return interactable != null;
    }
}
