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

    [SerializeField] private float enemyDamage;

    public Collider2D HitboxCollider { get => hitboxCollider; set => hitboxCollider = value; }

    void Start()
    {
        aimTransform = GetComponent<Transform>();

        enemy.OnEnemyAttack += Enemy_OnEnemyAttack;

    }
    private void Enemy_OnEnemyAttack()
    {
        hitBoxDirection = (enemy.aIDestinationSetter.target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(hitBoxDirection.y, hitBoxDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PaladinHitBox"))
        {
            collision.GetComponent<PaladinHealth>().TakeDamage(enemyDamage);
        }

        else if (collision.CompareTag("PlayerHitBox"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
        }

    }

}
