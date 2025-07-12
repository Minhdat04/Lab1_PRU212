using UnityEngine;
using System.Collections;

public class SmartRobotVacuum2D : MonoBehaviour
{
    [Tooltip("Speed of the robot vacuum")]
    public float moveSpeed = 5f;

    private Vector2 moveDirection;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Ensure consistent physics behavior.
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.linearDamping = 0f;

        // Initialize movement direction (for example, facing right).
        moveDirection = transform.right;
        rb.linearVelocity = moveDirection * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a tagged "Furniture" or "Wall" object.
        if(collision.gameObject.CompareTag("Furniture") || collision.gameObject.CompareTag("Wall"))
        {
            ContactPoint2D contact = collision.contacts[1];

            // Reflect the movement direction and normalize to maintain constant speed.
            moveDirection = Vector2.Reflect(moveDirection, contact.normal).normalized;
            rb.linearVelocity = moveDirection * moveSpeed;
        }

    }
}