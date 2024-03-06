using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float speed = 2.50f;
    [SerializeField]private float jumpForce = 10f;
    public float scaleUpIncrement = 1.2f;
    public float scaleDownIncrement = 0.85f;
    private Rigidbody2D rigidBody2D;
    private bool isGrounded = true;
    private float movementInput;

    public int healthPoints = 3;
    public bool isDead = false;
    public int score;
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

    public void UpdateScore(int newScore)
    {
        score = newScore;
    }
    public void UpdateHealth()
    {
        healthPoints--;
        if (healthPoints == 0)
        {
            isDead = true;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreObject"))
        {
            transform.localScale *= scaleUpIncrement;
        }
        if (collision.CompareTag("Bomb"))
        {
            transform.localScale *= scaleDownIncrement;
        }
    }*/
}
