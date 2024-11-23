using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 50; // Hedefin canı

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject); // Hedefi yok et
    }
}
