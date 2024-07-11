using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    public GameObject wall;
    float speedOpen = 5f;
    float speedClose = 1f;

    private Vector3 originalPosition;

    private bool playerOnPlatform;
    void Start()
    {
        originalPosition = wall.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnPlatform)
        {
            //El condicional limita el movimiento del muro, buscar hacer din�mico el l�mite
            if (wall.transform.position.y > -2.62)
            {
                wall.transform.Translate(Vector3.down * speedOpen * Time.deltaTime);
            }
        }
        else
        {
            wall.transform.position = Vector3.Lerp(wall.transform.position, originalPosition, speedClose * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            Debug.Log("Im here");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
            Debug.Log("Im leave the platform");
        }
    }
}
