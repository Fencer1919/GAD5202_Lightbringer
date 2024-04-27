using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] private OathTracker oathTracker;

    [SerializeField] private float meleeDamage;

    [SerializeField] private GameObject hitBox;
    private Vector2 hitBoxDirection;
    private Transform aimTransform;

    public static event Action onEnemyKilledMelee;

    public float MeleeDamage { get => meleeDamage; set => meleeDamage = value; }

    private void Start()
    {
        aimTransform = GetComponent<Transform>();

        AttackState.onAttack += Player_onAttack;
        OathTracker.onOathBreak += OnOathBreak;
    }

    private void OnOathBreak()
    {
        if(oathTracker.isOathBroken)
        {
            meleeDamage /= 2;
        }
        else
        {
            meleeDamage *= 2;
        }
    }

    private void Player_onAttack()
    {       
        hitBoxDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(hitBoxDirection.y, hitBoxDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent(out EnemyHealth hit))
        {
            hit.TakeDamage(meleeDamage);

            if (collider.GetComponent<EnemyHealth>().IsDead)
            {
                onEnemyKilledMelee?.Invoke();
            }
        }
    }

}
