using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; 
    public Vector3 offset; 
    public float smoothSpeed = 0.125f; 
    private float xOffset = 0.19f;
    private float yOffset = 8.06f;
    private float zOffset = -9.15f;

    private void Start()
    {
        offset.x = xOffset;
        offset.y = yOffset;
        offset.z = zOffset;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
