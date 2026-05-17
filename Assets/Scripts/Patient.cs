using UnityEngine;

public class Patient : MonoBehaviour
{
    public float speed = 2f;
    private bool isHealed = false;
    private bool atWall = false;
    
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    
    void Update()
    {
        if (isHealed)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y < -6f) Destroy(gameObject);
            return;
        }
        
        if (atWall) return;
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit: " + other.gameObject.name + " with tag: " + other.gameObject.tag);
        
        if (other.gameObject.CompareTag("Wall"))
        {
            atWall = true;
            Debug.Log("Patient at wall = TRUE");
        }
    }
    
    public void Heal()
    {
        Debug.Log("Heal() called - atWall=" + atWall + ", isHealed=" + isHealed);
        
        if (atWall && !isHealed)
        {
            isHealed = true;
            GetComponent<SpriteRenderer>().color = Color.green;
            Debug.Log("PATIENT HEALED!");
        }
    }
}