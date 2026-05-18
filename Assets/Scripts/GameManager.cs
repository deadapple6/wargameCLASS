using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int maxDeaths = 5;
    private int currentDeaths = 0;
    public GameObject gameOverPanel;  // Drag GameOverCanvas here
    
    void Start()
    {
        Instance = this;
        
        // Hide Game Over panel at start
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }
    
    public void PatientDied()
    {
        if (currentDeaths >= maxDeaths) return;
        
        currentDeaths++;
        Debug.Log("Patient died! " + currentDeaths + "/" + maxDeaths);
        
        if (currentDeaths >= maxDeaths)
        {
            GameOver();
        }
    }
    
    void GameOver()
    {
        Debug.Log("GAME OVER!");
        
        // Show Game Over panel
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        
        // Stop spawning new patients
        Spawner spawner = FindObjectOfType<Spawner>();
        if (spawner != null)
            spawner.StopSpawning();
        
    }
    
    public void RestartGame()
    {
        Debug.Log("Restarting game...");
        
        // Resume time if it was stopped
        Time.timeScale = 1f;
        
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}
