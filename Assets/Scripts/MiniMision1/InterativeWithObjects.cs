using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterativeWithObjects : MonoBehaviour
{

    public GameObject panel1;
    public Inventory inventory;
    public bool playerNear;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update(){
        if (Input.GetKeyDown (KeyCode.X) && playerNear == true){
               
                inventory.Cantidad = inventory.Cantidad + 1;
                Destroy(gameObject);
             }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            panel1.SetActive(true); 
            playerNear = true;
        }else{
            panel1.SetActive(false);
            playerNear = false;
        }

    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
        {
            panel1.SetActive(false); 
            playerNear = false;
    }
}
}
