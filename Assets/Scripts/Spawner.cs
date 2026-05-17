using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject patientPrefab;
    
    void Start()
    {
        // Start after 2 seconds, repeat every 5 seconds
        InvokeRepeating("SpawnPatient", 2f, 4f);
    }
    
    void SpawnPatient()
    {
        float randomY = Random.Range(-1.25f, 1.25f);
        Vector3 spawnPosition = new Vector3(8f, randomY, 0f);
        Instantiate(patientPrefab, spawnPosition, Quaternion.identity);
    }
}