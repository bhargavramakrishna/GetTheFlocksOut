using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    private ActivableObject activableObject; // The object to be activated (e.g., door)

    [SerializeField]
    private PressurePlate linkedPlate; // The other plate linked to this one (if any)

    [SerializeField]
    private bool needsKey; // Does this plate require a key?

    [SerializeField]
    private bool doubleActivation; // Does this plate require both plates to be activated?

    private bool isActive = false; // Is this plate currently active?
    private bool keyPresent = false; // Is the player with the key on this plate?
    private bool objectActivated = false; // Tracks if the object has been permanently activated (for doubleActivation)

    private Animator animator; // Animator for the plate's animation

    private void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component attached to the plate
    }

    // Called when something enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player is on the plate
        {
            KeyInteraction playerKey = other.GetComponent<KeyInteraction>(); // Get the player's key interaction script

            // Check if the key is required and present
            if (needsKey && playerKey != null && playerKey.HasKey())
            {
                keyPresent = true; // Mark key as present
                isActive = true; // Mark the plate as active
                animator.SetBool("Press", true); // Trigger activation animation
            }
            else if (!needsKey) // If no key is needed
            {
                isActive = true; // Mark the plate as active
                animator.SetBool("Press", true); // Trigger activation animation
            }

            ValidateActivation(); // Validate if the object should be activated
        }
    }

    // Called when something exits the trigger area
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player left the plate
        {
            isActive = false; // Mark the plate as inactive
            keyPresent = false; // Remove key presence
            animator.SetBool("Press", false); // Trigger deactivation animation

            if (!doubleActivation) // If not a double activation, deactivate the object when the player leaves
            {
                activableObject.ResetWall();
            }
            else if (!objectActivated) // If doubleActivation but not permanently activated yet
            {
                ValidateActivation(); // Revalidate the object's activation state
            }
        }
    }

    // Validates whether the object should be activated or deactivated
    private void ValidateActivation()
    {
        // If double activation is required
        if (doubleActivation)
        {
            // Both plates must be active to activate the object
            if (isActive && linkedPlate != null && linkedPlate.IsActive() && !objectActivated)
            {
                activableObject.Activate(); // Activate the object
                objectActivated = true; // Mark the object as permanently activated
            }
        }
        else if (isActive) // If only this plate is needed
        {
            activableObject.Activate(); // Activate the object
        }
    }

    // Returns whether the plate is active and valid
    public bool IsActive()
    {
        return isActive && (!needsKey || keyPresent); // Ensure the key condition is satisfied if required
    }
}
