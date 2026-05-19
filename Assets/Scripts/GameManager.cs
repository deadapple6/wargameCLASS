using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int maxDeaths = 5;
    private int currentDeaths = 0;
    private bool isGameOver = false;
    public GameObject gameOverPanel;
    
    void Start()
    {
        Instance = this;
        currentDeaths = 0;
        isGameOver = false;
        
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }
    
    public void PatientDied()
    {
        if (isGameOver) return;
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
        if (isGameOver) return;
        isGameOver = true;
        
        Debug.Log("GAME OVER!");
        
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        
        Spawner spawner = FindObjectOfType<Spawner>();
        if (spawner != null)
            spawner.StopSpawning();
    }
    
    public void RestartGame()
    {
        isGameOver = false;
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}
