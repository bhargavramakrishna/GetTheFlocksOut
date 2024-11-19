using UnityEngine;

public class ActivableObject : MonoBehaviour, IActivable
{
    // Variables to control the movement
    public Vector3 targetPosition;  // Target position where the wall will move
    public float moveSpeed = 2f;    // Movement speed of the wall
    private bool isMoving = false;  // Flag to check if the wall is moving

    private Vector3 initialPosition;  // The initial position of the wall

    void Start()
    {
        // Store the initial position of the wall
        initialPosition = transform.position;
    }

    void Update()
    {

        Wallmovement();

    }

    // Method from the IActivable interface to start the movement
    public void Activate()
    {
        // When activated, the wall starts moving
        isMoving = true;
    }

    // Method to reset the wall back to its initial position (if needed)
    public void ResetWall()
    {
        transform.position = initialPosition;
        isMoving = false;
    }

    public void Wallmovement()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // If the wall reached the target position, stop the movement
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }
}
