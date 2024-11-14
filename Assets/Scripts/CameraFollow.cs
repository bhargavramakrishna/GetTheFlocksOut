using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Vector3 publicOffSet;

    private Vector3 offset = new Vector3(0f, 10f, -15f);
    private float smoothSpeed = 0.01f;
    [HideInInspector]
    public Transform target; 

    private Vector3 targetPosition;

    private void Start()
    {
        offset = publicOffSet;
    }

    private void LateUpdate()
    {
        offset = publicOffSet;

        if (target != null)
        {
            targetPosition = target.position + offset;
            
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        
        target = newTarget;
    }
}
