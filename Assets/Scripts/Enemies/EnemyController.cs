using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hp;
    public int weaponDamage;
    public Animator anim;
    
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "weaponImpact")
       { 

          if (anim != null)
          {
            anim.Play("EnemiesImpact");
          }

          hp -= weaponDamage;

       }

       if(hp <= 0)
       {
         anim.Play("EnemiesDeath");
         //anim.SetBool("EnemiesDeath", true);
         //Destroy(gameObject);
       }
        
    }

}
