using UnityEngine;

public class PlayerTrackingCamera : MonoBehaviour
{
    public Transform playerTransform; // Referencia al transform del jugador
    public Transform cameraRightShoulder; // Eje de la cámara
    public Transform cameraHolder; // Movimiento de la cámara con respecto al personaje (posición, rotación)
    private Transform cam;

    public float rotationSpeed = 200;
    public float minAngle = -45;
    public float maxAngle = 45;
    public float cameraSpeed = 200;

    private void Start()
    {
        cam = Camera.main.transform;
    }

    private void LateUpdate()
    {
        CameraControl();
    }

    private void CameraControl()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaT = Time.deltaTime;

        float rotX = mouseX * rotationSpeed * deltaT;

        playerTransform.Rotate(0, rotX, 0);

        Quaternion localRotation = Quaternion.Euler(-Mathf.Clamp(mouseY, minAngle, maxAngle), 0, 0);
        cameraRightShoulder.localRotation = localRotation;

        cam.position = Vector3.Lerp(cam.position, cameraHolder.position, cameraSpeed * deltaT);
        cam.rotation = Quaternion.Lerp(cam.rotation, cameraHolder.rotation, cameraSpeed * deltaT);
    }
}
