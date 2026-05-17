using UnityEngine;

public class Doctor : MonoBehaviour
{
    public float speed = 5f;
    
    void Update()
    {
        // W/S movement
        float moveY = 0f;
        if (Input.GetKey(KeyCode.W)) moveY = 1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;
        
        transform.Translate(0, moveY * speed * Time.deltaTime, 0);
        
        // Keep doctor on screen
        float clampedY = Mathf.Clamp(transform.position.y, -4f, 4f);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        
        // Heal with Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("=== SPACE PRESSED ===");
            Debug.Log("Doctor position: " + transform.position);
            
            GameObject[] patients = GameObject.FindGameObjectsWithTag("Patient");
            Debug.Log("Found " + patients.Length + " patients");
            
            foreach (GameObject p in patients)
            {
                float distance = Vector2.Distance(transform.position, p.transform.position);
                Patient patient = p.GetComponent<Patient>();
                
                Debug.Log("Patient at Y:" + p.transform.position.y + " | Distance: " + distance + " | CanBeHealed: " + patient.CanBeHealed());
                
                if (patient != null && patient.CanBeHealed() && distance < 3.5f)
                {
                    Debug.Log("★★★ HEALING! ★★★");
                    patient.Heal();
                    break;
                }
            }
        }
    }
}