using System.Collections;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseObject; 
    private bool isPaused = false;
    private bool canAct = true; 

    void Update()
    {
        if (canAct)
        {
            if (pauseObject.activeSelf && !isPaused)
            {
                StartCoroutine(PauseGame());
            }
            else if (!pauseObject.activeSelf && isPaused)
            {
                StartCoroutine(UnpauseGame());
            }
        }
    }

    IEnumerator PauseGame()
    {
        canAct = false; 
        yield return new WaitForSecondsRealtime(0.3f);
        Time.timeScale = 0;
        isPaused = true;
        canAct = true; 
    }

    IEnumerator UnpauseGame()
    {
        canAct = false; 
        yield return new WaitForSecondsRealtime(0.3f); 
        Time.timeScale = 1; 
        isPaused = false;
        canAct = true; 
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
