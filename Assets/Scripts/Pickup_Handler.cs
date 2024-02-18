using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Handler : MonoBehaviour
{
    public AudioClip pickupSound;
    public AudioSource pickupAudioSource;
    public GameSessionManager gameSession;
    /* Approach adapted from https://docs.unity3d.com/410/Documentation/ScriptReference/index.Accessing_Other_Game_Objects.html */

    Pickup_Spawn spawnPoint;
    [SerializeField] int scoreValue;
    [SerializeField] int collectibleValue;


    // Start is called before the first frame update
    void Start()
    {
        pickupAudioSource = GetComponent<AudioSource>();
        spawnPoint = transform.parent.gameObject.GetComponent<Pickup_Spawn>();
        gameSession = FindObjectOfType<GameSessionManager>();
        scoreValue = 1000;
        collectibleValue = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            spawnPoint.toggleActive();
            if (gameSession != null)
            {
                gameSession.AddScore(scoreValue);
                gameSession.AddCollectible(collectibleValue);
            }
            /*pickupAudioSource.PlayOneShot(pickupAudioSource.clip, 1f);*/
            AudioSource.PlayClipAtPoint(pickupAudioSource.clip, Camera.main.transform.position);
            playPickupSound();
            Destroy(gameObject);

            Debug.Log("Pickup Encountered in handler");
        }
    }

    public void playPickupSound()
    {
        pickupAudioSource.PlayOneShot(pickupSound, 1f);
    }
}
