using UnityEngine;
using UnityEngine.InputSystem;

public class Doctor : MonoBehaviour
{
    public float speed = 5f;
    public Transform checkTarget;
    
    private float moveY = 0f;
    
    void Update()
    {
        transform.Translate(0, moveY * speed * Time.deltaTime, 0);
        
        float clampedY = Mathf.Clamp(transform.position.y, -4f, 4f);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveY = input.y;
    }

    private void OnInteract(InputValue value)
    {
        Collider2D[] nearby = Physics2D.OverlapCircleAll(checkTarget.position, 1f);
        Debug.Log(nearby.Length);
            
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