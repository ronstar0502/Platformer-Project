using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.50f;
    public float jumpForce = 10f;
    private Rigidbody2D rigidBody2D;
    private bool isGrounded = true;
    private float movementInput;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rigidBody2D.velocity = new Vector2(movementInput * speed, rigidBody2D.velocity.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            rigidBody2D.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platforms")) // Ensure your ground objects have the tag "Ground"
        {
            isGrounded = true;
        }
    }
}
