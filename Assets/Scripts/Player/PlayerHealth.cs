using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private OathTracker oathTracker;

    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    private bool isDead = false;

    public bool IsDead { get => isDead; set => isDead = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    public void Awake()
    {
        OathTracker.onOathBreak += OnOathBreak;
    }

    public void OnOathBreak()
    {
        if(oathTracker.isOathBroken)
        {
            currentHealth *= 2;
        }
        else
        {
            currentHealth /= 2;
        }
    }


    public void TakeDamage(float damageValue)
    {
        CurrentHealth -= damageValue;

        UIManager.Instance.SetHealthBar(CurrentHealth);

        if(CurrentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        IsDead = true;
        playerController.ChangeState(new DeadState());
    }

}
