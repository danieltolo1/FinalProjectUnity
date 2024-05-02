using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringKey : MonoBehaviour
{
    public GameObject panelTakeKey;
    public GameObject panelbringKey;
    public HasKey hasKey;
    public bool playerNear;

    // Start is called before the first frame update
    void Start()
    {
        hasKey = GameObject.FindGameObjectWithTag("Player").GetComponent<HasKey>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && playerNear == true)
        {

            hasKey.key = true;
            Destroy(gameObject);
            panelTakeKey.SetActive(false);
            panelbringKey.SetActive(true);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            panelTakeKey.SetActive(true);
            playerNear = true;
        }
        else
        {
            panelTakeKey.SetActive(false);
            playerNear = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            panelTakeKey.SetActive(false);
            playerNear = false;
        }
        else
        {
            panelTakeKey.SetActive(true);
            playerNear = true;
        }
    }
}
