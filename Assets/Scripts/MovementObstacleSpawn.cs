using UnityEngine;

public class MovementObstacleSpawn : MonoBehaviour
{
    public float speed;
    public float limitRight = 29.54f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(transform.position.x > limitRight)
        {
            Destroy(gameObject);
        }
    }
}
