using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private ActivableObject Activable;

    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {

        //here you can put the rock condition when the rock gets done [if CompareTag "rock"]
        Activable.Activate();
        animator.SetBool("Press", true);
    }

    public void OnTriggerExit(Collider other)
    {
        Activable.ResetWall();
        animator.SetBool("Press", false);
    }

}
