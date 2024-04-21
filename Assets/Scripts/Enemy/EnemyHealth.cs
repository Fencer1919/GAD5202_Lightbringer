using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyHealthValue;
    [SerializeField] private float rangedEnemyHealthValue;


    public int enemyMeleeExperience;
    [SerializeField] private int rangedEnemyExperience;

    public MainEnemy enemy;

    public static event Action<int> onEnemyDeath;



    private bool isDead = false;

    public float EnemyHealthValue { get => enemyHealthValue; set => enemyHealthValue = value; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public int RangedEnemyExperience { get => rangedEnemyExperience; set => rangedEnemyExperience = value; }

    void Start()
    {
        PlayerDamageManager.EnemyDamaged += TakeDamage;
    }


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

        if(!enemy.IsRangedEnemy)
        {
            onEnemyDeath?.Invoke(enemyMeleeExperience);
        }
        else
        {
            onEnemyDeath?.Invoke(rangedEnemyExperience);
        }

    }

    public void DeadStateActive()
    {
        enemy.ChangeState(new EnemyDeadState());
    }
}
