using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    // Start is called before the first frame update
    public AudioClip[] musicSounds,sfxSounds;
    public AudioSource audioSource, sfxSource;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { 
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(1);
    }

    public void PlayMusic(int pos)
    {
        AudioClip clip = musicSounds[pos];

        if (clip == null)
        {
            Debug.Log("Audio not found");
        }
        else { 
            audioSource.clip = clip;
            audioSource.Play(); 
        }
    }

    public void PlaySfx(int pos)
    {
        AudioClip clip = sfxSounds[pos];

        if (clip == null)
        {
            Debug.Log("Audio not found");
        }
        else
        {
            sfxSource.clip = clip;
            sfxSource.Play();
        }
    }

}
