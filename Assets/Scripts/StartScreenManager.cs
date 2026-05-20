using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject spawner;
    public GameObject doctor;
    
    void Start()
    {
        // Show start screen
        if (startCanvas != null)
            startCanvas.SetActive(true);
        
        // Pause the game
        Time.timeScale = 0f;
        
        // Disable spawner and doctor movement
        if (spawner != null) spawner.SetActive(false);
        if (doctor != null) doctor.GetComponent<Doctor>().enabled = false;
    }
    
    public void StartGame()
    {
        // Hide start screen
        if (startCanvas != null)
            startCanvas.SetActive(false);
        
        // Resume game
        Time.timeScale = 1f;
        
        // Enable spawner and doctor
        if (spawner != null) spawner.SetActive(true);
        if (doctor != null) doctor.GetComponent<Doctor>().enabled = true;
    }
    
    public void QuitGame()
    {
        // Works in built game
        Application.Quit();
        
        // For testing in Unity Editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}