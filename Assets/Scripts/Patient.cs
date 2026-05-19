using UnityEngine;

public class Patient : MonoBehaviour
{
    public float speed = 2f;
    public float timeToHeal = 5f;
    
    private bool isHealed = false;
    private bool atWall = false;
    private float currentTimer;
    private SpriteRenderer spriteRenderer;
    private bool isDying = false;  //prevents double death
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        currentTimer = timeToHeal;
        Debug.Log("Patient spawned");
    }
    
    void Update()
    {
        // Healed - move down
        if (isHealed)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y < -6f) Destroy(gameObject);
            return;
        }
        
        // At wall - countdown timer
        if (atWall)
        {
            currentTimer -= Time.deltaTime;
            
            // Flash when almost dead
            if (currentTimer < 1f)
            {
                float flash = Mathf.PingPong(Time.time * 10f, 0.5f);
                spriteRenderer.color = flash > 0.25f ? Color.red : Color.white;
            }
            
            if (currentTimer <= 0f)
            {
                Die();
            }
            return;
        }
        
        // Move left toward wall
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit: " + other.gameObject.name);
        
        if (other.gameObject.CompareTag("Wall"))
        {
            atWall = true;
            Debug.Log("Reached wall! Timer started.");
        }
    }
    
    public bool CanBeHealed()
    {
        return atWall && !isHealed && currentTimer > 0;
    }
    
    public void Heal()
    {
        if (CanBeHealed())
        {
            isHealed = true;
            spriteRenderer.color = Color.green;
            Debug.Log("PATIENT HEALED!");
        }
    }
    
    void Die()
    {
        if (isDying) return;  // prevents double death
        isDying = true;      
        
        Debug.Log("Patient died!");
        spriteRenderer.color = Color.gray;
        
        if (GameManager.Instance != null)
            GameManager.Instance.PatientDied();
        
        Destroy(gameObject, 0.5f);
    }
}