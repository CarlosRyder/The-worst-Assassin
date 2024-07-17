using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementShuriken : MonoBehaviour
{
    // Start is called before the first frame update
    private float speedRotation = 150f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * Time.deltaTime * speedRotation, speedRotation);
    }
}
