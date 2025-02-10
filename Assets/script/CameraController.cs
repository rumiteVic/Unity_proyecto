using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Referencia al transform del personaje
    public Transform player;

    // Offset para ajustar la posici�n de la c�mara respecto al jugador
    public Vector3 offset;

    // Velocidad de suavizado
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (player != null)
        {
            // Posici�n deseada basada en el jugador y el offset
            Vector3 desiredPosition = player.position + offset;

            // Suavizado de la c�mara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Actualizar la posici�n de la c�mara
            transform.position = smoothedPosition;
        }
    }
}
