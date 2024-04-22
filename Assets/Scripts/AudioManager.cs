using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource sfxAudioSource, musicAudioSource;

    public static AudioManager Instance { get; private set; } //Tambien la protegemos //Se puede acceder desde otro script AudioManager.Instance.

    //Limitamos instancias.

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            //Para que el audio perdure a los cambios de scena.
            DontDestroyOnLoad(this);
        }
    }

    //Reproducir sonidos desde otro script.
    public void PlaySound(AudioClip clip)
    {
        //Para reproducir el sonido que se le pasa por argumentos.
        sfxAudioSource.PlayOneShot(clip);
    }

    //Metodo para mutear o activar sonido.

    private void ToggleMusic()
    {
        musicAudioSource.mute = !musicAudioSource.mute;
    }

    public void ButtonMuteSountrack()
    {
        musicAudioSource.mute = !musicAudioSource.mute;
    }

    public void ButtonMutesfxAudioSource()
    {
        sfxAudioSource.mute = !sfxAudioSource.mute;
    }

    //LLamo el metodo para que mientrastanto lo reconozca por una tecla.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) ToggleMusic();
    }



}
