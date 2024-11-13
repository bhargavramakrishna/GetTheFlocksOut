using UnityEngine;

public class AnimControl : MonoBehaviour
{

    private Animator animator;
    private Rigidbody rb;


    private static readonly int Run = Animator.StringToHash("run");
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();




    }

    // Update is called once per frame
    void Update()
    {
        HandleRunAnimation();
    }


    private void HandleRunAnimation()
    {
        float speed = new Vector3(rb.linearVelocity.x,0,rb.linearVelocity.z).magnitude;


        animator.SetFloat(Run, speed);
    }
}
