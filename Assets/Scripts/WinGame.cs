using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameObject winPanel; 

    void Start()
    {
        winPanel.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WinRoom")
            )
        {
            WinGamePanel();
        }
    }

    public void WinGamePanel()
    {
        winPanel.SetActive(true);
    }
}
