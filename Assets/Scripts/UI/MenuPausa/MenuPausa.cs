using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public TestController testController;
    public CameraController cameraController;

    public bool Pausa = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa == false)
            {
                ObjetoMenuPausa.SetActive(true);
                Pausa = true;
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                testController.speed = 0;
                cameraController.rotationSpeed = 0;
                testController.gravityForce = 15;
                testController.isOnGround = false;

            }
            else if (Pausa == true)
            {
                Resumir();
            }
        }
    }

    public void Resumir()
    {

        ObjetoMenuPausa.SetActive(false);
        Pausa = false;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        testController.speed = 4;
        cameraController.rotationSpeed = 1.5f;
    }

    public void goToMenu(string MenuName)
    {
        SceneManager.LoadScene(MenuName);
    }
}
