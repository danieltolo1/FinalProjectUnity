using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movimiento Player

    Transform playerTr;
    Rigidbody playerRb;

    private float moveX;
    private float moveZ;
    private float deltaT;
    public float gravityModifier;

    Vector3 direction;
    Vector3 side;
    Vector3 forward;

    public float walkSpeed = 200;
    public float jumpForce = 25000;
    public bool isOnGround;
    public bool jump;
    public GameObject triggerJump;

    // Movimiento de la Cámara

    public float mouseX;
    public float mouseY;
    private float rotY = 0f;
    private float rotX;

    public Transform cameraRightShoulder; // Eje de la cámara
    public Transform cameraHolder; // Movimiento de la cámara con respecto al personaje (posición, rotación)
    private Transform cam;    

    public float rotationSpeed = 200;
    public float minAngle = -45;
    public float maxAngle = 45;
    public float cameraSpeed = 200;

    // Animaciones 

    Animator anim;
    private Vector2 animSpeed;

    
    void Start()
    {
        playerTr = transform;
        cam = Camera.main.transform;

        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        MoveControl();        
        ActionsControl();
        CameraControl();
        AnimControl();
    }

    public void CameraControl()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        deltaT = Time.deltaTime;

        rotY += mouseY * rotationSpeed * deltaT;

        rotX = mouseX * rotationSpeed * deltaT;

        playerTr.Rotate(0, rotX, 0);

        rotY = Mathf.Clamp(rotY, minAngle, maxAngle);

        Quaternion localRotation = Quaternion.Euler(-rotY, 0, 0);
        cameraRightShoulder.localRotation = localRotation;

        cam.position = Vector3.Lerp(cam.position, cameraHolder.position, cameraSpeed * deltaT);
        cam.rotation = Quaternion.Lerp(cam.rotation, cameraHolder.rotation, cameraSpeed * deltaT);
    }

    public void MoveControl()
     {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        deltaT = Time.deltaTime;        

        animSpeed = new Vector2(moveX, moveZ);       

        side = walkSpeed * moveX * deltaT * playerTr.right;
        forward = walkSpeed * moveZ * deltaT * playerTr.forward; 

        direction = side + forward;
       
        playerRb.velocity = direction;

     }

     public void ActionsControl()
     {
        //Saltar
        jump = Input.GetKey(KeyCode.Space);

        if (isOnGround) 
        {
            if (jump)
            {
                playerRb.AddForce(transform.up * jumpForce);
            }
        }
     }

     public void AnimControl()
     {
        anim.SetBool("ground", isOnGround);
        anim.SetFloat("X", animSpeed.x);
        anim.SetFloat("Y", animSpeed.y);
     }

}
