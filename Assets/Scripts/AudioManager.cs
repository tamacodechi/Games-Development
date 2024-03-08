using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds, idleMotorSounds,crashSound, reverseSound, lightMusicSound;
    public AudioSource musicSource, sfxSource, idleMotorSource, crashSoundSource, reverseSoundSource, lightMusicSource;
   


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
        PlayLightBackgroundMusic("LightBackgroundMusic"); 

        StartIdleMotorSound(); 


    }

    private void Update()
    {
        // Engine sound logic for moving forward
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartEngineSound();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            StopEngineSound();
        }

        // Reverse sound logic for moving backward
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartReverseSound(); // Play the reverse sound when the down arrow key is pressed
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            StopReverseSound(); // Stop the reverse sound when the down arrow key is released
        }
    }



    // Playing City Background Music 
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


    // Adding Ligh Background Sound
    public void PlayLightBackgroundMusic(string name)
    {
        Sound s = Array.Find(lightMusicSound, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Music sound not found: " + name);
            return;
        }

        lightMusicSource.clip = s.clip;
        lightMusicSource.loop = true; 
        lightMusicSource.Play();
    }



    // Idling Sound 
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
            sfxSource.loop = true; // Looping here  the sound so it continues playing
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


    // Sound when the car hits 
    public void PlayBumpSound()
    {
        Sound s = Array.Find(crashSound, sound => sound.name == "Bump");
        if (s == null)
        {
            Debug.LogWarning("Bump sound not found.");
            return;
        }

        crashSoundSource.PlayOneShot(s.clip); 
    }

    // Starting playing the reverse sound
    public void StartReverseSound()
    {
        Sound s = Array.Find(reverseSound, sound => sound.name == "Reverse"); 
        if (s == null)
        {
            Debug.LogWarning("Reverse sound not found.");
            return;
        }

        if (!reverseSoundSource.isPlaying)
        {
            reverseSoundSource.clip = s.clip;
            reverseSoundSource.loop = true; 
            reverseSoundSource.Play();
        }
    }

    // Stops playing the reverse sound
    public void StopReverseSound()
    {
        if (reverseSoundSource.isPlaying)
        {
            reverseSoundSource.Stop();
        }
    }



}
