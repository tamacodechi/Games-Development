using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Handler : MonoBehaviour
{
    public AudioClip pickupSound;
    public AudioSource pickupAudioSource;
    public AudioSource parentAudioSource;
    /*public GameSessionManager gameSession;*/
    /*public PlayerManager playerManager;*/
    public PlayerStats playerStats;
    /* Approach adapted from https://docs.unity3d.com/410/Documentation/ScriptReference/index.Accessing_Other_Game_Objects.html */

    Pickup_Spawn spawnPoint;
    [SerializeField] int scoreValue = 1000;
    [SerializeField] int collectibleValue = 1;


    // Start is called before the first frame update
    void Start()
    {
        parentAudioSource = transform.parent.gameObject.GetComponent<AudioSource>();
        pickupAudioSource = GetComponent<AudioSource>();
        spawnPoint = transform.parent.gameObject.GetComponent<Pickup_Spawn>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            spawnPoint?.toggleActive();
            if (playerStats != null)
            {
                playerStats.AddToScore(scoreValue);
                playerStats.AddToPickupsCollected();
            }
            //Works - sound origination is from spawn        
            parentAudioSource.Play(0);

            //Works - sound origination is from camera
            //AudioSource.PlayClipAtPoint(pickupAudioSource.clip, Camera.main.transform.position);

            //Works - Sound orignation is from pickup
            //playPickupSound();

            //pickupAudioSource.Play(0);
            //pickupAudioSource.PlayOneShot(pickupAudioSource.clip, 1f);



            
        }
    }

    public void playPickupSound()
    {
        pickupAudioSource.PlayOneShot(pickupSound, 1f);
    }
}
