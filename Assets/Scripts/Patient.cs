using UnityEngine;

public class Patient : MonoBehaviour
{
    public float speed = 3.5f;  //
    public float timeToHealAtWall = 4f;  // 4 seconds to heal 
    
    private bool isHealed = false;
    private bool atWall = false;
    private float currentTimer;
    private SpriteRenderer spriteRenderer;
    private bool isDying = false;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        currentTimer = timeToHealAtWall;
    }
    
    void Update()
    {
        if (isHealed)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y < -6f) Destroy(gameObject);
            return;
        }
        
        // Timer ONLY runs when at wall
        if (atWall)
        {
            currentTimer -= Time.deltaTime;
            
            // Flash when about to die
            if (currentTimer < 0.8f)
            {
                float flash = Mathf.PingPong(Time.time * 10f, 0.5f);
                spriteRenderer.color = flash > 0.25f ? Color.red : Color.white;
            }
            
            if (currentTimer <= 0f)
            {
                Die();
                return;
            }
        }
        
        if (atWall) return;
        
        // Move left toward wall
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            atWall = true;
            Debug.Log("Patient reached wall! Heal within " + timeToHealAtWall + " seconds!");
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
        if (isDying) return;
        isDying = true;
        
        Debug.Log("Patient died!");
        spriteRenderer.color = Color.gray;
        
        if (GameManager.Instance != null)
            GameManager.Instance.PatientDied();
        
        Destroy(gameObject, 0.5f);
    }
}