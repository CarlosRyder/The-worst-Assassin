using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObstaclePlatform : MonoBehaviour
{
    public GameObject player;
    Vector3 originalPosition;
    public GameObject[] waypoints;
    public float speedObject;
    int waypointsIndex = 0;


    private void Start()
    {
        originalPosition = player.transform.localScale;
    }

    void Update()
    {

        if (Vector3.Distance(transform.position, waypoints[waypointsIndex].transform.position) < 0.1f)
        {
            waypointsIndex++;
        }
        if (waypointsIndex >= waypoints.Length)
        {
            waypointsIndex = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointsIndex].transform.position, speedObject * Time.deltaTime);

    }
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            // Establece el padre (plataforma)
            collision.gameObject.transform.SetParent(transform);
            collision.gameObject.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
            collision.gameObject.transform.localScale = originalPosition;
        }
    }
}
