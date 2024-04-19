using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public float rangedDamage;

    [SerializeField] private PlayerDamageManager playerDamageManager;

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //damage enemy
        if(collision.CompareTag("Enemy"))
        {
            PlayerDamageManager.instance.DamageEnemy(rangedDamage);
        }
    }
}
