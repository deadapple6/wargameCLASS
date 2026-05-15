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
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x > 10f) Destroy(gameObject);
            return;
        }
        
        if (atWall) return;
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall")) atWall = true;
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
