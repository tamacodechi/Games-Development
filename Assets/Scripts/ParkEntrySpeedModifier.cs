using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkEntrySpeedModifier : MonoBehaviour
{
    public carController carController;
    [SerializeField] float parkMotorTorque = 4000f;
    [SerializeField] float parkBrakeTorque = 3000f;
    [SerializeField] float parkSteeringAngle = 30f;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            carController.setBrakeForce(parkBrakeTorque);
            carController.setBrakeForce(parkBrakeTorque);
            carController.setSteeringAngle(parkSteeringAngle);
        }
    }
}
