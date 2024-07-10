using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    public int lives = 5; 
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

    public void GainLife()
    {
        lives++; 
        UpdateLivesText(); 
    }

    void UpdateLivesText(){
        livesText.text = "    : " + lives; 
    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Saw") || collision.gameObject.CompareTag("Arrow") || collision.gameObject.CompareTag("Shuriken")
            || collision.gameObject.CompareTag("Windmill") || collision.gameObject.CompareTag("Enemy"))
        {
            GameObject canvas = GameObject.Find("Canvas"); 
            LifeCounter lifeCounter = canvas.GetComponent<LifeCounter>();
            lifeCounter.LoseLife(); 
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
