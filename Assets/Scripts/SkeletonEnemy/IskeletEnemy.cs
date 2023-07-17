using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IskeletEnemy : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 100;
    public int currentHealth;

    IskeletAI iskeletai;

    void Start()
    {
        currentHealth = maxHealth;
        iskeletai = GetComponent<IskeletAI>();
        
    }


    public void TakeDamage(int damage) //hasar alma ile ilgili iþlemler
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");

        if (currentHealth<=0)
        {
            Die();
        }


    }

    void Die() //Ölüm animasyonunu çaðýrýr ve düþmaný 2 saniye sonra yok eder
    {
        anim.SetBool("IsDead",true);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;

        iskeletai.followspeed = 0;

        Destroy(gameObject, 2f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<HealthController>().DecreaseHealth(1);
        
    }


    
    




}
