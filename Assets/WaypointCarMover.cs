﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCarMover : MonoBehaviour
{

    // Stores a reference to the waypoint system which the car will need to use
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;


    private Transform currentWaypoint; 

    // Start is called before the first frame update
    void Start()
    {
        // Set inital position of car to first Waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        //Setting next Waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, currentWaypoint.position)< distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);

        }
    }
}
