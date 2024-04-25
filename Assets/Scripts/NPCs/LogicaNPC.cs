using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;


public class LogicaNPC : MonoBehaviour
{
    public GameObject simboloMision;
    public GameObject panelNPCStarConversation;
    public GameObject panelNPCConversation1;
    public GameObject panelNPCConversation2;
    public GameObject panelNPCConversation3;
    public GameObject panelNPCMision;
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject botonDeMision;

    public TestController testController;
    public CameraController cameraController;

    public GameObject[] ObjetosMision1;
    public GameObject[] PanelesMision1;

    // Start is called before the first frame update
    void Start()
    {
        //simboloMision.SetActive(true);
        testController = GameObject.FindGameObjectWithTag("Payer").GetComponent<TestController>();
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


            //testController.moveZ = 0;

        }
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
        aceptarMision = true;
        testController.speed = 4;
        cameraController.rotationSpeed = 1.5f;
        for (int i = 0; i < ObjetosMision1.Length; i++)
        {
            ObjetosMision1[i].SetActive(true);
        }
        for (int i = 0; i < PanelesMision1.Length; i++)
        {
            PanelesMision1[i].SetActive(true);
        }
    }
}
