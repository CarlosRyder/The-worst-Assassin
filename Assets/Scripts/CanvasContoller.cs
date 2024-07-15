using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasContoller : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameOverPanel;
    private bool isPaused = false;
    private bool canAct = true;

    public void Start()
    {
        startPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if (canAct)
        {
            if (startPanel.activeSelf && !isPaused)
            {
                StartCoroutine(PauseGame());
            }
            else if (!startPanel.activeSelf && isPaused)
            {
                StartCoroutine(UnpauseGame());
            }
        }

        if (gameOverPanel.activeSelf)
        {
            StartCoroutine(PauseGame());
        }
    }

    IEnumerator PauseGame()
    {
        canAct = false;
        yield return new WaitForSecondsRealtime(0.3f);
        Time.timeScale = 0;
        isPaused = true;
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

    public void GameDefined(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
