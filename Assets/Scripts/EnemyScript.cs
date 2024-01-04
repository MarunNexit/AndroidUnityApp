using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public int damage = 10;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Hit");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Логіка для смерті ворога
        Destroy(gameObject);
    }
}
