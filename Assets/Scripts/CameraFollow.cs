using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 5f, -15f); // Posição da câmera relativa ao jogador
    private float smoothSpeed = 0.01f; // A suavidade do movimento da câmera

    [HideInInspector]
    public Transform target; // O alvo que a câmera deve seguir

    private Vector3 targetPosition;

    private void LateUpdate()
    {
        if (target != null)
        {
            // Calcula a posição do alvo mais o offset
            targetPosition = target.position + offset;
            // Move suavemente a câmera para a nova posição
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        // Define um novo alvo para a câmera seguir
        target = newTarget;
    }
}
