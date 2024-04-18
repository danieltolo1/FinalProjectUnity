using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
          player.isOnGround = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Floor")
        {
          player.isOnGround = false;
        }
    }
}
