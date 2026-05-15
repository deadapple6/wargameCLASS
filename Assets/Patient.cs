using UnityEngine;

public class Patient : MonoBehaviour
{
    public float speed = 2f;
    private bool isHealed = false;
    private bool atWall = false;
    
    void Update()
    {
        if (isHealed)
        {
            // MOVES DOWN instead of right
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y < -6f) Destroy(gameObject);
            return;
        }
        
        if (atWall) return;
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall")) atWall = true;
    }
    
    public void Heal()
    {
        if (atWall && !isHealed)
        {
            isHealed = true;
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
