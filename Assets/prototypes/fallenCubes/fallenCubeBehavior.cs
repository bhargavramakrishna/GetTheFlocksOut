using UnityEngine;

public class FallenCubeBehavior : MonoBehaviour
{
    private int count = 0; // Collision count
    private int maxHp = 4; // Number of collisions needed to activate physics

    [SerializeField]
    private Material blockMaterial; // Material of the cube
    private Rigidbody rb; // Rigidbody reference

    [SerializeField]
    private Color[] colors; // Array of colors

    private int colorIndex = 0; // Index of the current color

    void Start()
    {
        blockMaterial = GetComponent<Renderer>().material; // Get the material from the cube's renderer
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component of the cube

        // Set the initial color if there are colors available
        if (colors.Length > 0)
            blockMaterial.color = colors[colorIndex];
    }

    // Called when the cube collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        // Increment the collision count and change the color
        countDown();
        changeMaterial();

        // If the collision count reaches the maxHp, the cube starts to fall
        if (count >= maxHp)
        {
            cubeFall();
        }
    }

    // Function to handle the collision count
    private void countDown()
    {
        if (count < maxHp) // Increment only if the collision count is less than maxHp
        {
            count++;
        }
    }

    // Function to change the color of the cube
    private void changeMaterial()
    {
        // Increment the color index, but ensure it doesn't go out of bounds
        if (colorIndex < colors.Length - 1)
        {
            colorIndex++; // Move to the next color in the array
        }
        blockMaterial.color = colors[colorIndex]; // Apply the new color to the material
    }

    // Function to activate physics and make the cube fall
    private void cubeFall()
    {
        // Enable physics (remove kinematic state) when the cube reaches the required collision count
        rb.isKinematic = false;
        rb.useGravity = true; // Apply gravity to the cube
    }
}
