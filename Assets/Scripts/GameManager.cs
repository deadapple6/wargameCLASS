using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int maxDeaths = 5;
    private int currentDeaths = 0;
    public GameObject gameOverPanel;
    
    void Start()
    {
        Instance = this;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }
    
    public void PatientDied()
    {
        currentDeaths++;
        Debug.Log("Deaths: " + currentDeaths + "/" + maxDeaths);
        
        if (currentDeaths >= maxDeaths)
        {
            GameOver();
        }
    }
    
    void GameOver()
    {
        Debug.Log("GAME OVER!");
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        
        Spawner spawner = FindObjectOfType<Spawner>();
        if (spawner != null) spawner.StopSpawning();
    }
    
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}