using UnityEngine;

public class Doctor : MonoBehaviour
{
    public float speed = 5f;
    
    void Update()
    {
        float moveY = 0f;
        if (Input.GetKey(KeyCode.W)) moveY = 1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;
        
        transform.Translate(0, moveY * speed * Time.deltaTime, 0);
        
        float clampedY = Mathf.Clamp(transform.position.y, -4f, 4f);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider2D[] nearby = Physics2D.OverlapCircleAll(transform.position, 2f);
            
            foreach (Collider2D thing in nearby)
            {
                if (thing.CompareTag("Patient"))
                {
                    Patient patient = thing.GetComponent<Patient>();
                    if (patient != null) patient.Heal();
                    break;
                }
            }
        }
    }
}