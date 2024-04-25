using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField] Transform followPlayer;
   [SerializeField] private float rotationSpeed = 2f;
   [SerializeField] private float distance = 5;
   [SerializeField] private float rotationX;
   [SerializeField] private float rotationY;
   float invertXVal;
   float invertYVal;
   [SerializeField] private float minAngle = -20;
   [SerializeField] private float maxAngle = 45;
   [SerializeField] Vector2 framingOffset;
   [SerializeField] bool invertX;
   [SerializeField] bool invertY;

   



    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        invertXVal = invertX ? -1 : 1;
        invertYVal = invertY ? -1 : 1;

        rotationX += Input.GetAxis("Mouse Y") * invertYVal * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minAngle, maxAngle);
        
        rotationY += Input.GetAxis("Mouse X") * invertXVal * rotationSpeed;

        var playerRotation = Quaternion.Euler(rotationX, rotationY, 0);

        var focusPosition = followPlayer.position + new Vector3(framingOffset.x, framingOffset.y, 0);

        transform.position = focusPosition - playerRotation * new Vector3(0, 0, distance);
        transform.rotation = playerRotation;
    }


    public Quaternion PlanarRotation => Quaternion.Euler(0, rotationY,0);
}
