using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentPlayerHealth;

    private bool isDead;

    public bool IsDead { get => isDead; set => isDead = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentPlayerHealth { get => currentPlayerHealth; set => currentPlayerHealth = value; }

    public void TakeDamage(float damageValue)
    {
        CurrentPlayerHealth -= damageValue;

        if(CurrentPlayerHealth <= 0)
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
