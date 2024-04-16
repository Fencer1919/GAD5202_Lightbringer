using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] LayerMask targetLayer;

    [SerializeField] GameObject targetGameObject;

    [SerializeField] private float sphereRadius;

    [SerializeField] private MainEnemy enemy;


    void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, sphereRadius, targetLayer);

        if (collider != null)
        {
            enemy.OnAlarmState = true; 

            targetGameObject = collider.gameObject;

            enemy.targetLocation = (targetGameObject.transform.position - transform.position).normalized;
        }
        else
        {
            enemy.OnAlarmState = false;
            targetGameObject = null;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);

    }
}
