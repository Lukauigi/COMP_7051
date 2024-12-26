using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public const float Ground_Check_Distance = 5f;
    
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    private bool isGrounded = false;

    // input actions
    private InputActions inputActions;
    private InputAction movement;
   
    // Component(s)
    Rigidbody rb;

    /// <inheritdoc />
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = new InputActions();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        print(isGrounded);
        Vector2 v2 = movement.ReadValue<Vector2>(); //read from raw input
        Vector3 move = new Vector3(v2.x * moveSpeed * Time.deltaTime, 0, v2.y * moveSpeed * Time.deltaTime); // convert to 3D space

        rb.AddForce(move, ForceMode.VelocityChange);
    }

    
    private void OnEnable()
    {
        movement = inputActions.Player.Movement;
        movement.Enable();

        // create a DoJump callback function
        inputActions.Player.Jump.performed += DoJump;
        inputActions.Player.Jump.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();

        // create a DoJump callback function
        inputActions.Player.Jump.performed -= DoJump;
        inputActions.Player.Jump.Disable();
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Bad ground check but allows for a wall jump so I allow it.
        if (collision.transform.position.y < transform.position.y)
        {
            isGrounded = true;
        }
    }
}
