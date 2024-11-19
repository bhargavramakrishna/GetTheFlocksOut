using UnityEngine;


public class KeyInteraction : MonoBehaviour
{
    private bool hasKey = false; // Tracks if the player has a key

    [SerializeField]
    private GameObject keyVisual; // Visual indicator for the key

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with a key
        if (!hasKey && other.gameObject.CompareTag("key"))
        {
            keyVisual.SetActive(true); // Show the key indicator
            Destroy(other.gameObject); // Destroy the key object
            hasKey = true; // Mark the player as having a key
        }
    }

    public bool HasKey()
    {
        // Return whether the player has a key
        return hasKey;
    }

    
    
}
