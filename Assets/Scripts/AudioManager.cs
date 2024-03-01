using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds, idleMotorSounds;
    public AudioSource musicSource, sfxSource, idleMotorSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("BackgroundCity");
        StartIdleMotorSound(); 


    }

    private void Update()
    {
        // Check if the "up" arrow key or the "down" arrow key is pressed down
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartEngineSound();
        }

        // Check if the "up" arrow key or the "down" arrow key is released
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            StopEngineSound();
        }
    }


    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
            return;
        }

        musicSource.clip = s.clip;
        musicSource.Play();
    }



    private void StartIdleMotorSound()
    {
        Sound idleMotorSound = Array.Find(idleMotorSounds, sound => sound.name == "IdleMotor");
        if (idleMotorSound == null)
        {
            Debug.Log("IdleMotor sound not found");
            return;
        }

        idleMotorSource.clip = idleMotorSound.clip;
        idleMotorSource.loop = true;
        idleMotorSource.Play();
    }



    // Starts playing the engine sound
    private void StartEngineSound()
    {
        Sound s = Array.Find(sfxSounds, sound => sound.name == "Engine");
        if (s == null)
        {
            Debug.Log("Engine sound not found");
            return;
        }

        // Ensure the sound is not already playing
        if (!sfxSource.isPlaying)
        {
            sfxSource.clip = s.clip;
            sfxSource.loop = true; // Loop the sound so it continues playing
            sfxSource.Play();
        }
    }




    // Stops playing the engine sound
    private void StopEngineSound()
    {
        // Stop the sound if it is playing
        if (sfxSource.isPlaying)
        {
            sfxSource.Stop();
        }
    }

}
