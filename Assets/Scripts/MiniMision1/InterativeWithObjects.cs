using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterativeWithObjects : MonoBehaviour
{

    public Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inventory.Cantidad = inventory.Cantidad + 1;
            Destroy(gameObject);
        }

    }
}
