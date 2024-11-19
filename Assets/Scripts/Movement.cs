using UnityEngine;

public class Movement : MonoBehaviour
{
    // Reference to Rigidbody component
    private Rigidbody Rigidbody;
    private float horizontal;
    private float vertical;

    // Reference to the child object's Transform (sprite)
    private Transform childSpriteTransform;
    //private Transform childSpriteKeyTransform; later to fix the key sprite

    // Movement speed of the player
    [SerializeField]
    private float moveSpeed = 5f;

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        Rigidbody = GetComponent<Rigidbody>();

        // Get the only child transform (assumes there is only one child)
        childSpriteTransform = transform.GetChild(0);
        //childSpriteKeyTransform = transform.GetChild(2); later to fix sprite key

        // Log an error if the child was not found
        if (childSpriteTransform == null)
        {
            Debug.LogError("Child object (sprite) not found!");
        }
    }

    private void Update()
    {
        // Get horizontal and vertical input values
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Handle player rotation based on input
        HandleRotation();
    }

    void FixedUpdate()
    {
        // Handle player movement
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Set velocity based on input and movement speed
        Vector3 movement = new Vector3(horizontal * moveSpeed, Rigidbody.linearVelocity.y, vertical * moveSpeed);
        Rigidbody.linearVelocity = movement;
    }

    private void HandleRotation()
    {
        // Check if player is moving left
        if (horizontal < 0)
        {
            // Rotate the main object to face left
            transform.rotation = Quaternion.Euler(0, 180, 0);

            // Rotate the child object locally on the X-axis
            childSpriteTransform.localEulerAngles = new Vector3(-30, 0, 0);
            
        }
        // Check if player is moving right
        else if (horizontal > 0)
        {
            // Rotate the main object to face right
            transform.rotation = Quaternion.Euler(0, 0, 0);

            // Reset the child object's local rotation
            childSpriteTransform.localEulerAngles = new Vector3(30, 0, 0);
           // childSpriteKeyTransform.localEulerAngles = new Vector3(30, 0, 0); later for the key sprite fixing
        }
    }
}
