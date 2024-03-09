using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cityEntrySpeedModifier : MonoBehaviour
{
    public carController carController;
    [SerializeField] float cityMotorTorque = 9000f;
    [SerializeField] float cityBrakeTorque = 2000f;
    [SerializeField] float citySteeringAngle = 15f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            carController.setBrakeForce(cityMotorTorque);
            carController.setBrakeForce(cityBrakeTorque);
            carController.setSteeringAngle(citySteeringAngle);
        }
    }
}
