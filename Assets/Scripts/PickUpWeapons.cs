using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapons : MonoBehaviour
{
    public GameObject[] weapon;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
          DisableWeapons();
        }
    }

    public void WeaponActivator(int number)
    {
        for (int i = 0; i < weapon.Length; i++)
        {
            weapon[i].SetActive(false);
        }

        weapon[number].SetActive(true);
    }


    public void DisableWeapons()
    {
       for (int i = 0; i < weapon.Length; i++)
        {
            weapon[i].SetActive(false);
        }
    }

}