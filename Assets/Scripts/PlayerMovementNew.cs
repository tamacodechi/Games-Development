using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float movementSpeed;
    [SerializeField] float forwardForce = 200f;
    [SerializeField] float rotationForce = 30f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forward = Input.GetAxisRaw("Vertical");
        float side = Input.GetAxisRaw("Horizontal");

        Vector3 newPos = new Vector3(side, 0, forward) * movementSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + newPos);

        //Forces will be used in final implementation
        // Unity has a wheel collider class specifically for realistic car movement
        // this system will have to be updated to implement that.
        /*        if (forward > 0)
                {
                    rb.AddForce(Vector3.forward * forwardForce);
                }
                else if (forward < 0)
                {
                    rb.AddForce(Vector3.back * forwardForce);
                }

                if (side < 0)
                {
                    rb.AddForce(Vector3.left * rotationForce);
                }
                else if (side > 0)
                {
                    rb.AddForce(Vector3.right * rotationForce);
                }*/
    }

    // ***This functionality should be moved to another class***
    //Pickup Behaviour:
    // When entering the collider for a pickup, the following events should take place:
    //      - The pickup should be removed from the game world
    //      - The player's carrying amount for the pickup type should be increased.
    //      - A sound should play indicating that the pickup has taken place
    // Future Functionality:
    //      -- Before executing the above steps, a check should be initiated against the player's
    //          carrying capacity.

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            Destroy(other.gameObject);
            Debug.Log("Encountered Pickup");
        }
    }
}
