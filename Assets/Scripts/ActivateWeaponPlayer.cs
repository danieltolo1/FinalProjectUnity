using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWeaponPlayer : MonoBehaviour
{
    public PickUpWeapons pickUpWeapons;
    public int numberWeapon;
    
    void Start()
    {
        pickUpWeapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PickUpWeapons>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            pickUpWeapons.WeaponActivator(numberWeapon);
            Destroy(gameObject);            
        }       
    }
}
