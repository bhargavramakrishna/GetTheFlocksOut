using UnityEngine;
using UnityEngine.Playables;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody Rigidbody;
    private float horizontal;
    private float moveSpeed;


    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        moveSpeed = 15f;

    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            
            Rigidbody.linearVelocity = new Vector2(horizontal * moveSpeed, Rigidbody.linearVelocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {

           Rigidbody.linearVelocity = new Vector2(horizontal * moveSpeed, Rigidbody.linearVelocity.y);  
        }
           

    }
}
