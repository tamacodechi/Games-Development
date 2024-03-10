using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Approach adapted from https://docs.unity3d.com/410/Documentation/ScriptReference/index.Accessing_Other_Game_Objects.html */
public class Pickup_Handler : MonoBehaviour
{
    public AudioClip pickupSound;
    public AudioSource pickupAudioSource;
    public AudioSource parentAudioSource;
    public PlayerStats playerStats;
    

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
            AudioManager.Instance.PlayPickupSound();
        }
    }
}
