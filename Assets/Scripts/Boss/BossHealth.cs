using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;
    public Animator anim;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }
    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        anim.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
            SceneManager.LoadScene("YouWinScene");
        }
    }

    void Die()
    {
        anim.SetBool("IsDead", true);   
    }
}
