using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // public TextMeshProUGUI textMeshTimer;
    public float timer = 0;
    public int min, seg;
    [SerializeField] TextMeshProUGUI textMeshTimer;

    public GameObject PanelGameOver;

    private float restante;
    private bool enMarcha;


    private void Awake()
    {
        restante = (min * 60) + seg;
        enMarcha = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enMarcha)
        {

            restante -= Time.deltaTime;

            // textMeshTimer.text = "" + timer.ToString("f0");

            if (restante < 1)
            {
                gameOverPanelOn();
                enMarcha = false;
            }

            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            textMeshTimer.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }

    }


    void gameOverPanelOn()
    {
        PanelGameOver.SetActive(true);
    }
}
