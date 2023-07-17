using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public int maxHealth;
    [SerializeField] public int currentHealth;

    public Animator anim;

    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        anim.SetTrigger("IsHit");
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();

        }
    }

    private void Die()
    {
        anim.SetBool("IsDead", true);
        Destroy(gameObject, 2f);
        SceneManager.LoadScene("GameOverScene");
    }
}

  
