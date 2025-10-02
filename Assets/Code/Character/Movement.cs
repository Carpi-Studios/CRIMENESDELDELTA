using UnityEngine;
public class Movement : MonoBehaviour
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
    [SerializeField] private float move_speed = 5.0f;


    /// <summary>
    /// Correction angle, if original rotation on Y axis change
    /// </summary>
    [SerializeField] private float AngleCorrection = 45;

    /// <summary>
    ///  Capsule height on normal state (iddle or running)
    /// </summary>
    [SerializeField] private float standingHeight = 1.0f;

    /// <summary>
    ///  Capsule height on Crouching state
    /// </summary>
    [SerializeField] private float crouchingHeight = 0.25f;

    /// <summary>
    ///  Movement speed when crouching
    /// </summary>
    [SerializeField] private float crouchSpeed = 2.5f;

    private bool isCrouching = false;
    private bool isInvisible = false;
    private float actualInvisibleTimer = 0;
    [SerializeField] private readonly float MAX_INVISIBLE_TIMER = 3f;

    [SerializeField] private float targetHeight = 1;

    [SerializeField] private Vector3 offset = new(0, -0.25f, 0);

    void Start()
    {
        _char_control = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Crouch")) Crouch();
        if (Input.GetButtonUp("Crouch") && !IsCeiling()) Stand();

        if (isInvisible)
        {
            actualInvisibleTimer += Time.deltaTime;
            if (actualInvisibleTimer >= MAX_INVISIBLE_TIMER || !_movement.Equals(Vector3.zero)) ResetInvisibility();
        }

        // Calculates the movement vector with an angle correction and normalize it
        _movement = Quaternion.AngleAxis(AngleCorrection, Vector3.up) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        // Adjust the vertor to the movement speed intended
        _movement *= (isCrouching ? crouchSpeed : move_speed) * Time.deltaTime;
        //Execute the movement
        _char_control.SimpleMove(_movement);

    }


    void Crouch()
    {
        if (!isInvisible && _movement.Equals(Vector3.zero)) isInvisible = true;

        isCrouching = !isCrouching;
        _char_control.height = crouchingHeight;
        _char_control.center = offset;
    }

    void Stand()
    {
        ResetInvisibility();
        isCrouching = !isCrouching;
        _char_control.height = targetHeight;
        _char_control.center = Vector3.zero;
    }

    bool IsCeiling()
    {
        if (Physics.Raycast(transform.position, Vector3.up, standingHeight + .2f)) return true;
        return false;
    }

    void ResetInvisibility()
    {
        actualInvisibleTimer = 0;
        isInvisible = false;
    }

    public bool IsInvisible()
    {
        Debug.Log("INVISIBLE: " + isInvisible);
        return isInvisible;
    }
}
