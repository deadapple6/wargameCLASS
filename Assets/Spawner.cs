using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnPatient, 2f, 5f"); // Start after 2 seconds, repeat every 5 seconds
        
    }


    void SpawnPatient()
    {
        float randomY = Random.Range(-3.5f, 3.5f);
        Vector3 spawnPosition = new Vector3(Vector3(8f, randomY, 0f));
        Instantiate(Patient, spawnPosition, Quaternion.identity);
    }
}
