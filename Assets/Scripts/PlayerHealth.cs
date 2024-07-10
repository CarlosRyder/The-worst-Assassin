using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;

    private void Start()
    {
        currentLives = maxLives;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            LoseLife();
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        //if (coll.CompareTag("sword")) 
        //{
        //    LoseLife();
        //}
    }

    private void Update()
    {
        Debug.Log("current lives: " + currentLives);
    }

    private void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--;

            if (currentLives <= 0)
            {
                Debug.Log("You lose"); //Lose Scene
            }
        }
    }

}

