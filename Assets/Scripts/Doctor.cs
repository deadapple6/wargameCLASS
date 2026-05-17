using UnityEngine;

public class Doctor : MonoBehaviour
{
    public float speed = 5f;
    public float healRange = 3f;  // Increased from 1.5 to 3
    
    void Update()
    {
        // W/S movement
        float moveY = 0f;
        if (Input.GetKey(KeyCode.W)) moveY = 1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;
        
        transform.Translate(0, moveY * speed * Time.deltaTime, 0);
        
        // Keep on screen
        float clampedY = Mathf.Clamp(transform.position.y, -4f, 4f);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        
        // Heal
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject[] patients = GameObject.FindGameObjectsWithTag("Patient");
            
            foreach (GameObject p in patients)
            {
                float distance = Vector2.Distance(transform.position, p.transform.position);
                Debug.Log("Distance to patient: " + distance);
                
                // Now heals within 3 units instead of 1.5
                if (distance < healRange)
                {
                    Patient patient = p.GetComponent<Patient>();
                    if (patient != null)
                    {
                        patient.Heal();
                        break;
                    }
                }
            }
        }
    }
}