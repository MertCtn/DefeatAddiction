using System;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = 3f; // Speed of the enemy movement
    [SerializeField] private float seperationDistance = 2f;
    [SerializeField] public float cohesionStrength = 1f; 

    private Rigidbody2D rb;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MoveTowardsTarget();
        Cohesion();
    }

    private void Cohesion()
    {
        Collider2D[] nearbyEnemies = Physics2D.OverlapCircleAll(transform.position, seperationDistance);

        Vector2 cohesionForce = Vector2.zero;

        foreach(Collider2D enemy in nearbyEnemies)
        {
            if(enemy.CompareTag("Enemy") && enemy != this.GetComponent<Collider2D>())
            {
                cohesionForce += (Vector2)enemy.transform.position - (Vector2)transform.position;
            }
        }

        if (nearbyEnemies.Length > 0)
        {
            cohesionForce /= nearbyEnemies.Length;  // Average direction of nearby enemies
            cohesionForce = cohesionForce.normalized * moveSpeed * cohesionStrength;

            rb.linearVelocity += cohesionForce * Time.deltaTime;
        }

    }

    private void MoveTowardsTarget()
    {
        if (target == null)
            return;

        // Calculate the direction from the enemy to the target
        Vector3 direction = (target.position - transform.position).normalized;

        // Move the enemy towards the target
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Rotate the enemy to face the target
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy Collided");
        }
    }
}

