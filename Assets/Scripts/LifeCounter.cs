using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    public int lives; 
    public TextMeshProUGUI livesText; 
    public GameObject gameOverPanel; 


    void Start()
    {
        UpdateLivesText(); 
        gameOverPanel.SetActive(false);
    }

    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--; 
            UpdateLivesText(); 
        }

        if (lives <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }

    void UpdateLivesText(){
        livesText.text = "     " + lives; 
    }
}
