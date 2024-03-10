using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionFlag : MonoBehaviour
{
    [SerializeField] float numToCollect = 20f;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerStats.playerStatsInstance.IsParkUnlocked())
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.playerStatsInstance.IsParkUnlocked())
        {
            this.gameObject.SetActive(false);
        }
    }
}
