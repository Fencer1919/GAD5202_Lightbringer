using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyHealthValue;


    [SerializeField] private int enemyExperience;

    public MainEnemy enemy;

    public static event Action<int> onEnemyDeath;

    private bool isDead = false;

    public float EnemyHealthValue { get => enemyHealthValue; set => enemyHealthValue = value; }
    public bool IsDead { get => isDead; set => isDead = value; }

    public void TakeDamage(float damageValue)
    {
        Debug.Log("Enemy Damaged!");        

        EnemyHealthValue -= damageValue;

        if(EnemyHealthValue <= 0)
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
