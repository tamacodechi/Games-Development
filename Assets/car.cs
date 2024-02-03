using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        // Move the car forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
}
