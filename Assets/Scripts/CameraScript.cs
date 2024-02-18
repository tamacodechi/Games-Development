using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target; // The target that our camera should follow
    public Vector3 offset; // The offset distance between the camera and the target
    public float smoothSpeed = 0.125f; // How smoothly the camera catches up to its target, we want to have it smooth

    void FixedUpdate()
    {
        // Calculate the desired position here 
        Vector3 desiredPosition = target.position + offset;
        // Setting our cameras position to the current position and its desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Apply the smoothed position
        transform.position = smoothedPosition;

        // Make the camera always look at the target
        transform.LookAt(target);
    }
}
