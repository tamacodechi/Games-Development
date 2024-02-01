using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform[] spawnPoints;
    public float spawnFrequency = 2.0f;

    private float lastSpawnTime = 0.0f;

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnFrequency)
        {
            SpawnCar();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnCar()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(carPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
    }
}
