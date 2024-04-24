using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip starSound;
    // Start is called before the first frame update
    public void StartLevel(string NameLevel)
    {
        SceneManager.LoadScene(NameLevel);

    }

    public void ChangeMenu(string NameLevel)
    {
        SceneManager.LoadScene(NameLevel);
    }

    public void ButtonSound()
    {
        AudioManager.Instance.PlaySound(starSound);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
