using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject patientPrefab;
    public float spawnDelay = 3f;
    
    // Line positions (Y coordinates) - patients will take turns
    private float[] linePositions = new float[] { -2f, -1f, 0f, 1f, 2f };
    private int currentLineIndex = 0;
    private float timer;
    
    void Start()
    {
        timer = Random.Range(1f, 2f); // Random first spawn
    }
    
    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0f)
        {
            SpawnPatient();
            // Random delay between spawns (1 to 4 seconds)
            timer = Random.Range(1.5f, 4f);
        }
    }
    
    void SpawnPatient()
    {
        if (patientPrefab != null)
        {
            // Cycle through line positions (0,1,2,3,4 then back to 0)
            float spawnY = linePositions[currentLineIndex];
            currentLineIndex++;
            if (currentLineIndex >= linePositions.Length)
                currentLineIndex = 0;
            
            Vector3 spawnPosition = new Vector3(8f, spawnY, 0f);
            Instantiate(patientPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Spawned patient at Y: " + spawnY);
        }
    }
    
    public void StopSpawning()
    {
        this.enabled = false;
    }
}