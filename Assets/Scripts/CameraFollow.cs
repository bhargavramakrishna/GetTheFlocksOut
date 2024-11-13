using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 5f, -15f); // Posi��o da c�mera relativa ao jogador
    private float smoothSpeed = 0.01f; // A suavidade do movimento da c�mera

    [HideInInspector]
    public Transform target; // O alvo que a c�mera deve seguir

    private Vector3 targetPosition;

    private void LateUpdate()
    {
        if (target != null)
        {
            // Calcula a posi��o do alvo mais o offset
            targetPosition = target.position + offset;
            // Move suavemente a c�mera para a nova posi��o
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        // Define um novo alvo para a c�mera seguir
        target = newTarget;
    }
}
