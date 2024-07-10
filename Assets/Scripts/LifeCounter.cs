using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    public int lives = 3; 
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
    
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("WinRoom") 
            )
        {
            WinGame();
        }
    }
    

    void UpdateLivesText(){
        livesText.text = "    : " + lives; 
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Enemy")) 
        {
            GameObject canvas = GameObject.Find("Canvas"); 
            LifeCounter lifeCounter = canvas.GetComponent<LifeCounter>();
            lifeCounter.LoseLife(); 
        }
    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy")
            )
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
