using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hp;
    public int weaponDamage; // Daño del arma
    public float radius = 5.0f; // Radio de detección
    public float speed = 2.0f;  // Velocidad de movimiento
    public float rotationSpeed = 5.0f; // Velocidad de rotación
    private bool alert; // Indica si el enemigo está alertado
    
    public LayerMask playerLayer; // Capa del jugador para detección
    public Transform player;  // Referencia al jugador  
    private Vector3 targetPosition; // Posición objetivo para el movimiento
    public Animator EnemyAnim;
    
    void Start()
    {
       EnemyAnim = GetComponent<Animator>();
       StartCoroutine(UpdatePlayerDetection()); // Inicia la corutina para detectar al jugador
    }    

   
    void Update()
    {
        if (alert) // Si el enemigo está alertado
        {
            LookAtPlayer(); // Mirar hacia el jugador
            MoveTowardsPlayer(); // Mueve hacia el jugador
        }
        else
        {
            // Si no está alerta, desactiva la animación de caminar
            EnemyAnim.SetBool("run", false);
        }

        // Si la salud es cero o menor, ejecuta la animación de muerte y destruye el objeto
       /* if (hp <= 0)
        {
            EnemyAnim.SetBool("EnemiesDeath", true); 
            float animationLength = EnemyAnim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
            Destroy(gameObject, animationLength);       
        } */
    }

    // Corutina para actualizar la detección del jugador
    private IEnumerator UpdatePlayerDetection()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f); // Intervalo de actualización
        while (true)
        {
            // Usar Physics.OverlapSphere para detección 3D
            alert = Physics.OverlapSphere(transform.position, radius, playerLayer).Length > 0;
            yield return wait;
        }
    }

    private void LookAtPlayer() // Método para hacer que el enemigo mire al jugador
    {
        if (player != null)
        {
            // Calcular la dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0; // Asegura que el giro sea solo en el plano horizontal

            // Obtener la rotación deseada para mirar al jugador
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            // Interpolar la rotación para un giro suave
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }

     // El enemigo sigue al jugador 
    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            targetPosition = player.position; // Posición del jugador
            Vector3 moveDirection = (targetPosition - transform.position).normalized; // Dirección del movimiento
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World); // Movimiento en 3D
            EnemyAnim.SetBool("run", true); // Activa la animación de caminar
        }
    }

    /* private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "weaponImpact")
       { 

          if (EnemyAnim != null)
          {
            EnemyAnim.Play("EnemiesImpact");
          }

          hp -= weaponDamage;

       }      
        
    } */

      private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
