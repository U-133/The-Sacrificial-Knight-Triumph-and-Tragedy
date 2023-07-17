using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class firebullet1 : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 5;
    public Rigidbody2D rb;
    private Boss boss;
    public event Action OnBulletCollision;

    private bool isFacingRight = true; // Karakterin sağa dönük olduğunu takip eden bir flag

    void Start()
    {
        rb.velocity = (isFacingRight ? transform.right : -transform.right) * speed;
    }

    public void SetDirection(bool isRight)
    {
        isFacingRight = isRight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss") || collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ground"))
        {
            BossHealth boss = collision.gameObject.GetComponent<BossHealth>();

            if(boss != null)
            {
                boss.TakeDamage(damage);
            } 
            Destroy(gameObject);
            OnBulletCollision?.Invoke();
        }
    }   
    
        
    
}
