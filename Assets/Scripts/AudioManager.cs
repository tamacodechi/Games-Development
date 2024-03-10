using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds, idleMotorSounds,crashSounds, reverseSound, lightMusicSound, brakingSound, pickupSound;
    public AudioSource musicSource, sfxSource, idleMotorSource, crashSoundSource, reverseSoundSource, lightMusicSource, brakingSoundSource, pickupSoundSource;
   


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
        loadAudioClips();
        PlayLightBackgroundMusic("LightBackgroundMusic");
    }

    private void Update()
    {

    }
    public void loadAudioClips()
    {
        LoadBackgroundNoise("BackgroundCity");
        LoadBackgroundMusic("LightBackgroundMusic");
        LoadCrashSound("Bump");
        LoadReverseSound("Reverse");
        LoadSFXSound("Engine");
        LoadIdleMotorSound();
        LoadBrakingSound("Braking");
        LoadPickupSound("Pickup");
    }

    public void LoadPickupSound(string name)
    {
        Sound ps = Array.Find(pickupSound, sound => sound.name == "Pickup");
        if (ps == null)
        {
            Debug.LogWarning("Pickup sound not found.");
            return;

        }
        pickupSoundSource.clip = ps.clip;
    }

    public void LoadBackgroundNoise(string name)
    {
        Sound s = Array.Find(musicSounds, sound => sound.name == name);
        musicSource.clip = s.clip;
    }
    
    
    public void LoadReverseSound(string name)
    {
        Sound s = Array.Find(reverseSound, sound => sound.name == "Reverse");
        if (s == null)
        {
            Debug.LogWarning("Reverse sound not found.");
            return;
            
        }
        reverseSoundSource.clip = s.clip;
        reverseSoundSource.loop = true;
    }
    
    public void LoadSFXSound(string name)
    {
        Sound s = Array.Find(sfxSounds, sound => sound.name == "Engine");
        if (s == null)
        {
            Debug.Log("Engine sound not found");
            return;
        }
        sfxSource.clip = s.clip;
        sfxSource.loop = true; // Looping here  the sound so it continues playing
    }

    public void LoadCrashSound(string name) 
    {
        Sound crashSound = Array.Find(crashSounds, sound => sound.name == "Bump");
        crashSoundSource.clip = crashSound.clip;

        if (crashSoundSource == null)
        {
            Debug.LogWarning("Bump sound not found.");
            return;
        }
    }


    // Playing City Background Music 
    public void PlayMusic(string name)
    {
        if (musicSource == null)
        {
            Debug.Log("Sound Not Found");
            return;
        }
        musicSource.Play();
    }

    public void PlayPickupSound()
    {
        if (pickupSoundSource != null)
        {
            pickupSoundSource.Play();
        }
    }

    // Adding Ligh Background Sound
    public void PlayLightBackgroundMusic(string name)
    {
        
        if (lightMusicSource == null)
        {
            Debug.LogWarning("Music sound not found: " + name);
            return;
        }


        lightMusicSource.Play();
    }

    public void LoadBackgroundMusic(string name)
    {
        Sound s = Array.Find(lightMusicSound, sound => sound.name == name);
        lightMusicSource.clip = s.clip;
        lightMusicSource.loop = true;
    }



    // Idling Sound 
    public void StartIdleMotorSound()
    {
        if(idleMotorSource != null)
        {
            idleMotorSource.Play();
        }
        
    }
    private void LoadIdleMotorSound()
    {
        Sound idleMotorSound = Array.Find(idleMotorSounds, sound => sound.name == "IdleMotor");
        idleMotorSource.clip = idleMotorSound.clip;
        idleMotorSource.loop = true;
        if (idleMotorSource == null)
        {
            Debug.Log("IdleMotor sound not found");
            return;
        }
    }



    // Starts playing the engine sound
    public void StartEngineSound()
    {


        // Ensure the sound is not already playing
        if (!sfxSource.isPlaying)
        {

            sfxSource.Play();
        }
    }




    // Stops playing the engine sound
    public void StopEngineSound()
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
        if(crashSoundSource != null)
        {
            crashSoundSource.Play();
            return;
        }
    }

    // Starting playing the reverse sound
    public void StartReverseSound()
    {
        if (!reverseSoundSource.isPlaying)
        {            
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

    public void LoadBrakingSound(string name)
    {
        Sound brakeSound = Array.Find(brakingSound, sound => sound.name == "Braking");
        if (brakeSound == null)
        {
            Debug.Log("Braking Sound not found");
            return;
        }
        brakingSoundSource.clip = brakeSound.clip;
        brakingSoundSource.loop = true;
    }
    public void StartBrakingSound()
    {
        if (!brakingSoundSource.isPlaying)
        {
            brakingSoundSource.Play();
        }
    }

    public void StopBrakingSound()
    {
        if (brakingSoundSource.isPlaying)
        {
            brakingSoundSource.Stop();
        }
    }


}
