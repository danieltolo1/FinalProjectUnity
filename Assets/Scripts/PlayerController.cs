using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    Transform playerTr;
    Vector3 velocity;
    private float moveX;
    private float moveZ;
    public float speed;
    public float jumpForce;
    private float distanceToGround;

    public int gravityForce = 0;
    public bool isOnGround;
    
    // Animaciones 
    Animator anim;
    private Vector2 animSpeed;

    // Movimiento de la Cámara
    CameraController cameraController;

    private void Awake() 
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }
    
    void Start()
    {
        playerTr = transform;        
        playerRb = GetComponent<Rigidbody>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;

        anim = GetComponent<Animator>();
    }

   
    private void FixedUpdate() 
    {
        MoveControl();
        Jumping();
        Attacking();
        AnimControl();                                
    }

    private void Attacking()
    {

      if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("hit");            
        }

    }

    private void MoveControl()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        if (moveX != 0 || moveZ != 0)
        {
            // Obtiene la dirección de la cámara en el plano horizontal
            Vector3 cameraForward = Vector3.Scale(cameraController.transform.forward, new Vector3(1, 0, 1)).normalized;
            
            // Dirección del movimiento según la entrada y la cámara
            Vector3 desiredDirection = (cameraForward * moveZ + cameraController.transform.right * moveX).normalized;

            // Rotación del jugador 
            playerTr.rotation = Quaternion.LookRotation(desiredDirection);

            // Movimiento del jugador
            Vector3 motion = desiredDirection * speed;
            velocity = motion;
        }
        else
        {
            velocity = Vector3.zero;
        }

        // Mantiene la velocidad en Y del Rigidbody
        velocity.y = playerRb.velocity.y;
        playerRb.velocity = velocity;
    }
    private bool IsGrounded()
    {
      // Crea un objeto RaycastHit para obtener información sobre la colisión
          RaycastHit hit;

      // Define el origen del rayo y la distancia
          Vector3 origin = transform.position;
          float distance = distanceToGround + 0.1f;
          Vector3 direction = Vector3.down;

      // Dibuja el rayo para su visualización
          Debug.DrawRay(origin, direction * distance, Color.red, 0.5f);  // 0.5 segundos de duración

      // Ejecuta el RayCast hacia abajo desde la posición del objeto
          bool isHit = Physics.Raycast(origin, Vector3.down, out hit, distance);

      // Retornar true si hay colisión
          return isHit;
    }

    private void Jumping()
    {
        if(Input.GetButtonDown("Jump") && IsGrounded()) 
        {
           playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
           isOnGround = IsGrounded() == true;  

        } else {
           GravityForce();
           isOnGround = IsGrounded() == false;         
        }
    }

    private void GravityForce()
    {
        playerRb.AddForce(gravityForce * Physics.gravity);
    }

     public void AnimControl()
    {
        animSpeed = new Vector2(moveX, moveZ);
        anim.SetBool("ground", isOnGround);        
        anim.SetFloat("X", animSpeed.x);
        anim.SetFloat("Y", animSpeed.y);
    }

}
