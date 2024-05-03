using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private AudioClip starSound;

    public TestController testController;
    public CameraController cameraController;

    public Inventory inventory;

    public GameObject player;

    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            testController.speed = 0;
            cameraController.rotationSpeed = 0;
            testController.gravityForce = 15;
            testController.isOnGround = false;
        }
    }

    public void ButtonSound()
    {
        AudioManager.Instance.PlaySound(starSound);
    }


    public void Restart(string ScenaStart)
    {
        if (inventory.Cantidad < 3)
        {
            SceneManager.LoadScene(ScenaStart);
        }
        if (inventory.Cantidad >= 4)
        {
            transform.position = new Vector3(-2.69510436f, 0.0500000119f, 88.7204285f);
        }
    }

    public void goToMenu(string MenuName)
    {
        SceneManager.LoadScene(MenuName);

    }
}
