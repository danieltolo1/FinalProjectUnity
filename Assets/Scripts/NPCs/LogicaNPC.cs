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

    // Start is called before the first frame update
    void Start()
    {
        simboloMision.SetActive(true);
        panelNPCStarConversation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && aceptarMision == false)
        {
            panelNPCStarConversation.SetActive(false);
            panelNPCConversation1.SetActive(true);
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
    }
}
