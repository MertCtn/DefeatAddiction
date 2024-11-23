using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // Mermi hızı
    private Rigidbody2D rb; // Rigidbody referansı

    void Start()
    {
            rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = transform.right * speed; // Mermiyi silahın ileri yönüne fırlat
            Destroy(gameObject, 2f); // 2 saniye sonra mermiyi yok et
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Target target = hitInfo.GetComponent<Target>();
        if (target != null)
        {
            target.TakeDamage(10); // Hasar uygula
        }
        Destroy(gameObject); // Çarpışmada mermiyi yok et
    }
}
