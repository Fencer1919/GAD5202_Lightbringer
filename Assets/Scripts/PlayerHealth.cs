using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private OathTracker oathTracker;

    [SerializeField] private float maxHealth;
    [SerializeField] private float currentPlayerHealth;

    private bool isDead = false;

    public bool IsDead { get => isDead; set => isDead = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentPlayerHealth { get => currentPlayerHealth; set => currentPlayerHealth = value; }

    public void Awake()
    {
        OathTracker.onOathBreak += OnOathBreak;
    }

    public void OnOathBreak()
    {
        if(oathTracker.isOathBroken)
        {
            currentPlayerHealth /= 2;
        }
        else
        {
            currentPlayerHealth *= 2;
        }
    }


    public void TakeDamage(float damageValue)
    {
        CurrentPlayerHealth -= damageValue;

        UIManager.Instance.SetHealthBar(CurrentPlayerHealth);

        if(CurrentPlayerHealth <= 0)
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
