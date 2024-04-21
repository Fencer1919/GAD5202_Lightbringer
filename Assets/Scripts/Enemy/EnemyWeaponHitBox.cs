using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponHitBox : MonoBehaviour
{
    [SerializeField] MainEnemy enemy;

    [SerializeField] GameObject hitBox;
    [SerializeField] Collider2D hitboxCollider;
    private Vector2 hitBoxDirection;
    private Transform aimTransform;

    [SerializeField] private GameObject bullet;

    [SerializeField] private float enemyDamage;

    //public static event Action onBulletFired;

    public Collider2D HitboxCollider { get => hitboxCollider; set => hitboxCollider = value; }

    void Start()
    {
        aimTransform = GetComponent<Transform>();

        enemy.OnEnemyAttack += Enemy_OnEnemyAttack;

    }
    private void Enemy_OnEnemyAttack()
    {
        if(!enemy.IsRangedEnemy)
        {
            hitBoxDirection = (enemy.aIDestinationSetter.target.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(hitBoxDirection.y, hitBoxDirection.x) * Mathf.Rad2Deg;
            aimTransform.eulerAngles = new Vector3(0, 0, angle);
        }
        else
        {
            //Instantiate(bullet, transform.position, Quaternion.identity);
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paladin"))
        {
            collision.GetComponent<PaladinHealth>().TakeDamage(enemyDamage);
        }

        else if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
        }

    }

}
