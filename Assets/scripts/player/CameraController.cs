using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Referencia al transform del personaje
    public Transform player;

    // Offset para ajustar la posición de la cámara respecto al jugador
    public Vector3 offset;

    // Velocidad de suavizado
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (player != null)
        {
            // Posición deseada basada en el jugador y el offset
            Vector3 desiredPosition = player.position + offset;

            // Suavizado de la cámara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Actualizar la posición de la cámara
            transform.position = smoothedPosition;
        }
    }
}
