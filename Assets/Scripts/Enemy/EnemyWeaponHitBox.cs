using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyWeaponHitBox : MonoBehaviour
{
    [SerializeField] MainEnemy enemy;
    [SerializeField] CharacterDetection detection;

    [SerializeField] GameObject hitBox;
    [SerializeField] Collider2D hitboxCollider;
    private Vector2 hitBoxDirection;
    private Transform aimTransform;

    [SerializeField] private GameObject bullet;

    [SerializeField] private float enemyDamage;

    public Collider2D HitboxCollider { get => hitboxCollider; set => hitboxCollider = value; }

    void Start()
    {
        aimTransform = GetComponent<Transform>();

        enemy.OnEnemyAttack += Enemy_OnEnemyAttack;

    }
    private void Enemy_OnEnemyAttack()
    {
        if(!enemy.isRangedEnemy)
        {
            hitBoxDirection = (enemy.aIPath.destination - transform.position).normalized;
            float angle = Mathf.Atan2(hitBoxDirection.y, hitBoxDirection.x) * Mathf.Rad2Deg;
            aimTransform.eulerAngles = new Vector3(0, 0, angle);
        }
        else
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerHealth hit))
        {
            hit.TakeDamage(enemyDamage);
        }
    }

}
