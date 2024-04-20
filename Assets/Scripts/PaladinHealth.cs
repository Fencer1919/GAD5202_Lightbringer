using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinHealth : MonoBehaviour
{
    [SerializeField] private float paladinHealthValue;

    private bool isDead = false;

    public float PaladinHealthValue { get => paladinHealthValue; set => paladinHealthValue = value; }
    public bool IsDead { get => isDead; set => isDead = value; }

    void Start()
    {
        PlayerDamageManager.EnemyDamaged += TakeDamage;
    }


    public void TakeDamage(float damageValue)
    {
        Debug.Log("Enemy Damaged!");
        PaladinHealthValue -= damageValue;

        if(PaladinHealthValue <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        IsDead = true;
        Destroy(gameObject, 2f);

        
    }
}
