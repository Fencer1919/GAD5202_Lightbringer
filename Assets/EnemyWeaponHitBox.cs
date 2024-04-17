using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponHitBox : MonoBehaviour
{
    [SerializeField] MainEnemy enemy;

    [SerializeField] GameObject hitBox;
    private Vector2 hitBoxDirection;
    private Transform aimTransform;
    // Start is called before the first frame update
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

}
