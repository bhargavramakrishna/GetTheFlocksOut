using UnityEngine;
using UnityEngine.Playables;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody Rigidbody;
    private float horizontal;
    private float vertical;

    [SerializeField]
    private float moveSpeed = 5f;


    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        

    }
    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        Vector3 movement = new Vector3(horizontal * moveSpeed, Rigidbody.linearVelocity.y+0.1f, vertical * moveSpeed);

        Rigidbody.linearVelocity = movement;
    }

    private void HandleRotation()
    {
        if(horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        } else if(horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}
