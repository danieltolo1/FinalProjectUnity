using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicaNPC2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject simboloMision;
    public GameObject panelNPCStarConversation;
    public GameObject panelNPCConversation1;
    public GameObject panelNPCConversation2;
    public GameObject panelNPCConversation3;


    public GameObject panelNPCMision;

    public bool jugadorCerca;
    public bool aceptarMision;

    public bool finalMision;
    public GameObject botonDeMision;

    public TestController testController;
    public CameraController cameraController;

    public Timer timer;

    public GameObject[] PanelesMision2;
    public GameObject panelFinishMision;
    public GameObject panelCongratulationMision;
    public GameObject DoorCastle;
    public GameObject npcMision3;



    // Start is called before the first frame update
    void Start()
    {
        simboloMision.SetActive(true);
        testController = GameObject.FindGameObjectWithTag("Player").GetComponent<TestController>();
        panelNPCStarConversation.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && aceptarMision == false && jugadorCerca == true)
        {
            Vector3 posicionJugador = new Vector3(transform.position.x, testController.gameObject.transform.position.y, transform.position.z);
            testController.gameObject.transform.LookAt(posicionJugador);
            panelNPCStarConversation.SetActive(false);
            panelNPCConversation1.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            testController.speed = 0;
            cameraController.rotationSpeed = 0;
        }

        // if (inventory.Cantidad == 4 && PlayerFar == 1)
        // {
        //     panelCongratulationMision.SetActive(true);
        //     for (int i = 0; i < PanelesMision1.Length; i++)
        //     {
        //         PanelesMision1[i].SetActive(false);
        //     }
        // }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = true;


            if (aceptarMision == false)
            {
                panelNPCStarConversation.SetActive(true);
            }
        }

        // if (inventory.Cantidad == 4 && other.tag == "Player")
        // {
        //     panelCongratulationMision.SetActive(false);
        //     npcMision2.SetActive(true);
        //     jugadorCerca = true;
        //     Cursor.visible = true;
        //     Cursor.lockState = CursorLockMode.None;
        //     panelFinishMision.SetActive(true);
        //     inventory.Cantidad = 0;
        // }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = false;
            panelNPCStarConversation.SetActive(false);
            panelNPCConversation1.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }
    }

    public void Panel1ToPanel2()
    {
        panelNPCConversation1.SetActive(false);
        panelNPCConversation2.SetActive(true);
        panelNPCConversation3.SetActive(false);
    }


    public void Panel2ToPanel3()
    {
        panelNPCConversation1.SetActive(false);
        panelNPCConversation2.SetActive(false);
        panelNPCConversation3.SetActive(true);
    }


    public void NoOption()
    {
        panelNPCConversation3.SetActive(false);
        panelNPCStarConversation.SetActive(true);
        testController.speed = 4;
        cameraController.rotationSpeed = 1.5f;
    }

    public void SiOption()
    {
        panelNPCConversation3.SetActive(false);
        panelNPCMision.SetActive(true);
        aceptarMision = true;




    }

    public void StartMision2()
    {
        panelNPCMision.SetActive(false);
        testController.speed = 4;
        cameraController.rotationSpeed = 1.5f;
        timer.min = 4;
        timer.seg = 2;
        cameraController.distance = 2f;
        cameraController.framingOffset = new Vector2(0, 2);
        for (int i = 0; i < PanelesMision2.Length; i++)
        {
            PanelesMision2[i].SetActive(true);
        }

    }

    public void FinishMision2()
    {
        panelFinishMision.SetActive(false);
        simboloMision.SetActive(false);
        DoorCastle.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }



}
