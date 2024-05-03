using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionConNPCs : MonoBehaviour
{
   public GameObject panelInteraction;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            panelInteraction.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            panelInteraction.SetActive(false);
        }

    }
}
