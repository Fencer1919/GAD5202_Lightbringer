using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] LayerMask targetLayer;
    [SerializeField] GameObject targetGameObject;
    [SerializeField] private float sphereRadius;

    private Collider2D detectionCollider;


    [Header("Reference")]
    [SerializeField] private MainEnemy enemy;

    void Update()
    {
        PlayerDetection();
    }

    public void PlayerDetection()
    {
        detectionCollider = Physics2D.OverlapCircle(transform.position, sphereRadius, targetLayer);

        if (detectionCollider != null)
        {
            targetGameObject = detectionCollider.gameObject;

            if (CheckWall())
            {
                enemy.OnAlarmState = true;
                enemy.aIDestinationSetter.target = targetGameObject.transform;
            }
        }
        else
        {
            enemy.OnAlarmState = false;
            enemy.aIDestinationSetter.target = null;
        }
    }

    private bool CheckWall()
    {
        RaycastHit2D hit;

        hit = Physics2D.Linecast(transform.position, targetGameObject.transform.position);

        if (hit.collider.CompareTag("Player"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);

    }
}
