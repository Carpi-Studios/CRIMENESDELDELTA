using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;

public class Character : MonoBehaviour, IInteract
{
    /// <summary>
    /// Variable for CharacterController component
    /// </summary>
    private CharacterController _char_control;

    /// <summary>
    /// Vector for character movement 
    /// </summary>
    private Vector3 _movement;

    /// <summary>
    /// Variable  for movement speed
    /// </summary>
    [SerializeField] private float _move_speed = 5.0f;
    [SerializeField] private float _angle_correction = 45f;


    /// <summary>
    /// Distance for checking distance for IInteractables <seealso cref="IInteractables"/>
    /// </summary>
    [SerializeField] private float _castDistance = 1.5f;
    
    /// <summary>
    /// Layer for interactable objects
    /// </summary>
    [SerializeField] private LayerMask interactableLayerMask;
    void Start()
    {
        _char_control = GetComponent<CharacterController>();
    }

    void Update()
    {

        // 
        _movement = Quaternion.AngleAxis(_angle_correction, Vector3.up) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        _movement *= _move_speed;
        _char_control.SimpleMove(_movement);

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
        int maxColliders = 5;
        Collider[] hitColliders = new Collider[maxColliders];
        int quantity = Physics.OverlapSphereNonAlloc(transform.position, _castDistance, hitColliders, interactableLayerMask);

        for (int i = 0; i < quantity; i++)
        {
            Collider collider = hitColliders[i];
            Debug.Log("Detectado: " + collider.name);

            IInteractable interactable = collider.GetComponent<IInteractable>();
            if (interactable != null)
                return interactable;
        }

        return null;
    }
}
