using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject firebullet1;
    public GameObject ultibullet1;
    public bool IsFacingRight;
    public PlayerMovement playerMovement;
    public float fireRate = 1f; // Ateş hızı (saniye cinsinden)
    private float nextFireTime = 0f; // Sonraki ateş zamanı
    private int enemyCount = 0; // Vurulan düşman sayısı
    public int enemyThreshold = 5; // Ultibullet için gereken düşman sayısı
    //private bool canShootUltiBullet = false; // Ultibullet atılabilir mi?

    public GameObject fb1;
    public GameObject ub1;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        IsFacingRight = playerMovement.IsFacingRight;

        if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time >= nextFireTime)
        {
            ShootFireBullet();
            nextFireTime = Time.time + fireRate; // Ateş hızına göre sonraki ateş zamanını ayarla
        }

        if(Time.time >= nextFireTime)
        {
            fb1.SetActive(true);
        }
        else if (Time.time < nextFireTime)
        {
            fb1.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && Time.time >= nextFireTime && enemyCount >= enemyThreshold)
        {
            ShootUltiBullet();
            nextFireTime = Time.time + fireRate; // Ateş hızına göre sonraki ateş zamanını ayarla
            enemyCount = 0; // Vurulan düşman sayısını sıfırla
            //canShootUltiBullet = false; // Ultibullet atıldığı için sıfırla
        }

        if(Time.time >= nextFireTime && enemyCount >= enemyThreshold)
        {
            ub1.SetActive(true);
        }
        else if(Time.time < nextFireTime || enemyCount < enemyThreshold) 
        {
            ub1.SetActive(false);
        }
    }

    void ShootFireBullet()
    {
        GameObject bullet = Instantiate(firebullet1, firePoint.position, firePoint.rotation);
        SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();
        Destroy(bullet, 2f);

        // Karakter sola döndüğünde merminin şeklini de sola döndür
        // Karakter sola döndüğünde merminin hareket yönünü de sola döndür
        if (!IsFacingRight)
        {
            bullet.transform.localScale = new Vector3(-Mathf.Abs(bullet.transform.localScale.x), bullet.transform.localScale.y, bullet.transform.localScale.z);
            SetBulletDirection(false);
        }
        else
        {
            SetBulletDirection(true);
        }
        bullet.GetComponent<firebullet1>().OnBulletCollision += IncreaseEnemyCount;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            IncreaseEnemyCount(); // Düşman vurulduğunda düşman sayısını artır
            //CheckUltiBulletAvailability(); // Ultibullet atabilirlik kontrolü
        }
    }

    void ShootUltiBullet()
    {
        GameObject bullet = Instantiate(ultibullet1, firePoint.position, firePoint.rotation);
        SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();
        Destroy(bullet, 2f);
        // Karakter sola döndüğünde merminin şeklini de sola döndür
        // Karakter sola döndüğünde merminin hareket yönünü de sola döndür
        if (!IsFacingRight)
        {
            bullet.transform.localScale = new Vector3(-Mathf.Abs(bullet.transform.localScale.x), bullet.transform.localScale.y, bullet.transform.localScale.z);
            SetUltiBulletDirection(false);
        }
        else
        {
            SetUltiBulletDirection(true);
        }
        bullet.GetComponent<ultibullet1>().OnBulletCollision += IncreaseEnemyCount;
    }

    public void SetBulletDirection(bool isRight)
    {
        firebullet1[] bullets = FindObjectsOfType<firebullet1>();

        foreach (firebullet1 bullet in bullets)
        {
            bullet.SetDirection(isRight);
        }
    }

    public void SetUltiBulletDirection(bool isRight)
    {
        ultibullet1[] bullets = FindObjectsOfType<ultibullet1>();

        foreach (ultibullet1 bullet in bullets)
        {
            bullet.SetDirection(isRight);
        }
    }

    public void IncreaseEnemyCount()
    {
        enemyCount++;
        /*
        if (enemyCount >= enemyThreshold && Time.time >= nextFireTime)
        {
            ShootUltiBullet();
            nextFireTime = Time.time + fireRate;
            enemyCount = 0;
        }*/
    }

    /*public void CheckUltiBulletAvailability()
    {
        if (enemyCount >= enemyThreshold)
        {
            canShootUltiBullet = true;
        }
    }*/
}
