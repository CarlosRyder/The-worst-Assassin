using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private float movX, movZ;
    public float degrees = 2;
    public float speed = 4;
    public float jumpForce = 6;
    public float fallMultiplier = 1; 
    private bool isJumping;
    private Vector3 movement;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");
        movZ = Input.GetAxisRaw("Vertical");
        movement = new Vector3(movX, 0, movZ).normalized;
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
        JumpFall();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void Movement() 
    {
        if (movement.magnitude > 0)
        {
            Vector3 move = transform.position + movement * Time.deltaTime * speed;
            playerRigidbody.MovePosition(move);

            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            playerRigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, degrees * Time.deltaTime));
        }
        else
        {
            //stop movement
            playerRigidbody.velocity = new Vector3(0, playerRigidbody.velocity.y, 0);
            playerRigidbody.angularVelocity = Vector3.zero; 
        }
    }

    private void Jump() 
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void JumpFall() 
    {
        if (playerRigidbody.velocity.y < 0)
        {
            playerRigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
}
