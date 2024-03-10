using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionFlag : MonoBehaviour
{
    public PlayerStats playerStats;
    [SerializeField] float numToCollect = 20f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.GetPlayerPickupsCollected() >= numToCollect)
        {
            this.gameObject.SetActive(false);
        }
    }
}
