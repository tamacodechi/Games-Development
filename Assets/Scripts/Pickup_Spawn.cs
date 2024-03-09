using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Spawn : MonoBehaviour
{
    public GameObject pickup;
    
    [SerializeField]
    float minTime = 5f;
    
    [SerializeField]
    float maxTime = 15f;

    float spawnTime;

    bool isActive = false;
    // Start is called before the first frame update
    private void Start()
    {
        spawnTime = Mathf.Round(Random.Range(minTime, maxTime));
    }


    private void FixedUpdate()
    {       
        if (!isActive && Time.fixedTime%spawnTime < Mathf.Epsilon)
        {
            isActive = true;
            GameObject pickupInstantiated = Instantiate(pickup, transform.position, transform.rotation);
            pickupInstantiated.transform.parent = gameObject.transform;
        }
    }

    public void toggleActive()
    {
        isActive = !isActive;
    }
}