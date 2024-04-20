using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyHealthValue;

    public MainEnemy enemy;



    private bool isDead = false;

    public float EnemyHealthValue { get => enemyHealthValue; set => enemyHealthValue = value; }
    public bool IsDead { get => isDead; set => isDead = value; }

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
    }

    public void DeadStateActive()
    {
        enemy.ChangeState(new EnemyDeadState());
    }
}
