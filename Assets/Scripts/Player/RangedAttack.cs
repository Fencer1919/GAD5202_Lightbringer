using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public float rangedDamage;

    [SerializeField] private PlayerDamageManager playerDamageManager;

    [SerializeField] private float detectionRadius;
    [SerializeField] private LayerMask targetLayer;

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //damage enemy
        if (collision.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.TakeDamage(rangedDamage);
        }
    }
}
