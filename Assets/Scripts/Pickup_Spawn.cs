using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Spawn : MonoBehaviour
{
    public GameObject pickup;
    
    [SerializeField]
    float minTime;
    
    [SerializeField]
    float maxTime;

    float spawnTime;

    bool isActive = false;
    // Start is called before the first frame update
    private void Start()
    {
        minTime = 0;
        maxTime = 15;
        spawnTime = Mathf.Round(Random.Range(minTime, maxTime));
    }


    private void FixedUpdate()
    {       
        if (!isActive && Time.fixedTime%spawnTime == 0)
        {
            GameObject pickupInstantiated = Instantiate(pickup, transform.position, transform.rotation);
            pickupInstantiated.transform.parent = gameObject.transform;
            isActive = true;
        }
    }

    public void toggleActive()
    {
        isActive = !isActive;
    }
}