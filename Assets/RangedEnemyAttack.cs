using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : MonoBehaviour
{
    public EnemyDetection enemyDetection;

    public float rangedEnemyDamage;

    void Update()
    {
        if(enemyDetection.targetGameObject != null)
        {
            transform.Translate(enemyDetection.targetGameObject.transform.position);
        }   
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.CompareTag("Paladin"))
        {
            collision.GetComponent<PaladinHealth>().TakeDamage(rangedEnemyDamage);
        }

        else if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(rangedEnemyDamage);
        }
    }
}
