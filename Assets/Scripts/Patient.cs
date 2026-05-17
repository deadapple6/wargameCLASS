using UnityEngine;

public class Patient : MonoBehaviour
{
    public float speed = 2f;
    public float timeToHeal = 5f;  // Seconds before patient dies
    
    private bool isHealed = false;
    private bool atWall = false;
    private float currentTimer;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        currentTimer = timeToHeal;
    }
    
    void Update()
    {
        // If healed, move DOWN off screen
        if (isHealed)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y < -6f) Destroy(gameObject);
            return;
        }
        
        // Timer: Only count down when at the wall (waiting to be healed)
        if (atWall && !isHealed)
        {
            currentTimer -= Time.deltaTime;
            
            // Visual feedback - show urgency!
            float timePercent = currentTimer / timeToHeal;
            
            if (timePercent < 0.3f)
            {
                // Rapid flash when almost dead
                float flash = Mathf.PingPong(Time.time * 10f, 0.5f);
                spriteRenderer.color = flash > 0.25f ? Color.red : Color.white;
            }
            else if (timePercent < 0.6f)
            {
                // Pulse darker red when half time left
                float pulse = Mathf.PingPong(Time.time * 2f, 0.3f);
                spriteRenderer.color = Color.Lerp(Color.red, new Color(0.5f, 0f, 0f), pulse);
            }
            
            // TIME'S UP!
            if (currentTimer <= 0f)
            {
                Die();
            }
        }
        
        if (atWall) return;
        
        // Move LEFT toward wall
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            atWall = true;
            Debug.Log("Patient at wall! " + timeToHeal + " seconds to heal!");
        }
    }
    
    public void Heal()
    {
        if (atWall && !isHealed && currentTimer > 0)
        {
            isHealed = true;
            spriteRenderer.color = Color.green;
            Debug.Log("Patient HEALED with " + currentTimer.ToString("F1") + " seconds left!");
        }
    }
    
    void Die()
    {
        Debug.Log("Patient DIED from waiting too long!");
        spriteRenderer.color = Color.gray;
        Destroy(gameObject, 0.5f);
    }
}