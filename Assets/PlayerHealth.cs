using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float playerHealth;

    private bool isDead;

    public bool IsDead { get => isDead; set => isDead = value; }

    public void TakeDamage(float damageValue)
    {
        playerHealth -= damageValue;

        if(playerHealth <= 0)
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
