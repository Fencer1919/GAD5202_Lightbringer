using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    [SerializeField] private int enemyExperience;

    public MainEnemy enemy;

    public static event Action<int> onEnemyDeath;

    private bool isDead = false;

    public bool IsDead { get => isDead; set => isDead = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    public void TakeDamage(float damageValue)
    {
        Debug.Log("Enemy Damaged!");        

        CurrentHealth -= damageValue;

        if(CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        IsDead = true;
        Destroy(gameObject, 2f);
        DeadStateActive();

        onEnemyDeath?.Invoke(enemyExperience);
    }

    public void DeadStateActive()
    {
        enemy.ChangeState(new EnemyDeadState());
    }
}
