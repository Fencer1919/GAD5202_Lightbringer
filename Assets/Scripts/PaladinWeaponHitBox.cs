using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinWeaponHitBox : MonoBehaviour
{
    [SerializeField] MainPaladin paladin;

    [SerializeField] GameObject hitBox;
    [SerializeField] Collider2D hitboxCollider;
    private Vector2 hitBoxDirection;
    private Transform aimTransform;

    [SerializeField] private float enemyDamage;

    public Collider2D HitboxCollider { get => hitboxCollider; set => hitboxCollider = value; }

    void Start()
    {
        aimTransform = GetComponent<Transform>();

        paladin.OnPaladinAttack += OnPaladinAttack;

    }
    private void OnPaladinAttack()
    {
        hitBoxDirection = (paladin.aIDestinationSetter.target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(hitBoxDirection.y, hitBoxDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.TakeDamage(enemyDamage);
        }
    }

}
