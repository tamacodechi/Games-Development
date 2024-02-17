using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerriesWheelRotation : MonoBehaviour
{
    public Transform rotationWheel;
    public float rotationSpeed = 10f; // Adjusting in the inspector for wheel rotation speed
    public float shakeMagnitude = 0.5f; // Adjusting here in inspector for shake intensity
    public float shakeSpeed = 5f; // creating shakes of the cabins

    private Transform[] cabins = new Transform[10]; // Array to hold the cabins

    // Start is called before the first frame update
    void Start()
    {
        // getting cabin 1-10
        for (int i = 0; i < cabins.Length; i++)
        {
            // Find the cabins as children of the rotationWheel and store them in the array
            cabins[i] = rotationWheel.Find("cabin " + (i + 1));

            // Check if the cabin is found or getting the error
            if (cabins[i] == null)
            {
                Debug.LogError("Cabin " + (i + 1) + " not found");
            }
        }
    }

    void Update()
    {
        // Rotate the wheel around its local z axis
        rotationWheel.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.Self);

        // Apply a shaking effect and keep each cabin upright
        for (int i = 0; i < cabins.Length; i++)
        {
            if (cabins[i] == null)
                continue;

            // Counteract the wheels rotation to keep the cabin upright
            cabins[i].Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime, Space.World);

            // Calculate a shake based on a sine wave over the time
            float shakeOffset = Mathf.Sin(Time.time * shakeSpeed + i) * shakeMagnitude; // +i to offset shakes

            // Creating now a local offset vector that moves the cabin left and right
            Vector3 localOffset = cabins[i].right * shakeOffset;

            // Apply here a local offset to the cabin's position
            cabins[i].Translate(localOffset * Time.deltaTime, Space.Self);
        }
    }
}
