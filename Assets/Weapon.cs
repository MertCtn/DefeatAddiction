using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint; // Ateş noktasının pozisyonu
    public GameObject bulletPrefab; // Mermi prefab'ı
    public float fireRate = 0.5f; // Ateş etme hızı

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime) // Sol mouse butonuna basıldığında ateşle
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        // Mermiyi firePoint pozisyonunda oluştur
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
