using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float returnSpeed = 10f;
    private Transform playerTransform;
    private CharacterController characterController;
    private bool isReturning = false;

    public void Initialize(CharacterController controller)
    {
        characterController = controller;
        playerTransform = controller.transform;
        StartCoroutine(ReturnAfterDelay(1f)); 
    }

    void Update()
    {
        ProjectileMovement();
    }

    IEnumerator ReturnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isReturning = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isReturning)
        {
            if (other.CompareTag("Enemy"))
            {
                isReturning = true;
            }
        }
    }

    public void ReturnToPlayer()
    {
        isReturning = true;
    }
    public void ProjectileMovement() 
    {
        if (!isReturning)
        {
            transform.Translate(Vector3.up * forwardSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            transform.position += directionToPlayer * returnSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, playerTransform.position) < 1f)
            {
                characterController.SetCanShoot(true);
                Destroy(gameObject);
            }
        }
    }
}
