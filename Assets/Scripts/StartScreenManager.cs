using UnityEngine;
using UnityEngine.SceneManagement;

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
        
        // Disable game
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
    
    public void QuitToMainMenu()
    {
   // reset time
   Time.timeScale = 1f; 
   // reloads scene
   SceneManager.LoadScene("SampleScene");
    }
}