using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public float rangedDamage;

    public PlayerController playerController;
    public GameObject rangedObj;

    public static event Action onEnemyKilled;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent(out EnemyHealth hit))
        {
            hit.TakeDamage(rangedDamage);

            if (collider.GetComponent<EnemyHealth>().IsDead)
            {
                onEnemyKilled?.Invoke();
            }
        }
    }
}
