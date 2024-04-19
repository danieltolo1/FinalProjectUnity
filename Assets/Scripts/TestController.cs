using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class TestController : MonoBehaviour
{
    Rigidbody playerRb;
    Transform playerTr;
    Vector3 velocity;
    private float moveX;
    private float moveZ;
    public float speed;
    public float jumpForce;
    private float distanceToGround;
    
    // Animaciones 

    Animator anim;
    private Vector2 animSpeed;

    // Movimiento de la Cámara

    public float mouseX;
    public float mouseY;
    private float deltaT;

    private float rotY = 0f;
    private float rotX;

    public Transform cameraRightShoulder; // Eje de la cámara
    public Transform cameraHolder; // Movimiento de la cámara con respecto al personaje (posición, rotación)
    private Transform cam;

    public float rotationSpeed = 200;
    public float minAngle = -45;
    public float maxAngle = 45;
    public float cameraSpeed = 200;



    void Start()
    {
        playerTr = transform;
        cam = Camera.main.transform;
        playerRb = GetComponent<Rigidbody>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;

        anim = GetComponent<Animator>();
    }

   
    private void FixedUpdate() 
    {
        MoveControl();  
        Jumping();
        CameraControl();              
          
    }

    private void LateUpdate()
    {
        AnimControl();    
    }

        public void CameraControl()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        deltaT = Time.deltaTime;

        //rotY += mouseY * rotationSpeed * deltaT;

        rotX = mouseX * rotationSpeed * deltaT;

        playerTr.Rotate(0, rotX, 0);

        rotY = Mathf.Clamp(rotY, minAngle, maxAngle);

        Quaternion localRotation = Quaternion.Euler(-rotY, 0, 0);
        cameraRightShoulder.localRotation = localRotation;

        cam.position = Vector3.Lerp(cam.position, cameraHolder.position, cameraSpeed * deltaT);
        cam.rotation = Quaternion.Lerp(cam.rotation, cameraHolder.rotation, cameraSpeed * deltaT);
    }

    private void MoveControl()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
       

        if(moveX != 0 || moveZ != 0)
        {
           Vector3 motion = (transform.forward * moveZ + transform.right * moveX).normalized * speed;
           velocity = motion;
        } else {
           velocity = Vector3.zero;
        } 

        velocity.y = playerRb.velocity.y;                  
        playerRb.velocity = velocity;
    }

    private bool IsGrounded()
    {
       return Physics.BoxCast(transform.position, new Vector3(0.4f, 0f, 0.4f), Vector3.down, Quaternion.identity, distanceToGround + 0.1f);
    }

    private void Jumping()
    {
        if(Input.GetButtonDown("Jump") && IsGrounded()) 
        {
           playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }
    }

     public void AnimControl()
    {
        animSpeed = new Vector2(moveX, moveZ);        
        anim.SetFloat("X", animSpeed.x);
        anim.SetFloat("Y", animSpeed.y);
    }

}
