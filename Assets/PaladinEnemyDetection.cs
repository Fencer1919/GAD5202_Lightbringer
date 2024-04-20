using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinEnemyDetection : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] LayerMask targetLayer;
    [SerializeField] LayerMask ignoreEnemyLayerMask;
    [SerializeField] LayerMask playerAndEnemyLayer;
    [SerializeField] GameObject targetGameObject;
    [SerializeField] private float sphereRadius;

    private Collider2D detectionCollider;

    [Header("Reference")]
    [SerializeField] private MainPaladin paladin;

    void Update()
    {
        PlayerDetection();
        CheckFacingRight();
    }

    private void CheckFacingRight()
    {
        if(paladin.aIDestinationSetter.target != null && (paladin.aIDestinationSetter.target.position - paladin.transform.position).x <= 0)
            {
                paladin.enemyAnim.SetBool("facingRight", false);
            }
            else
            {
                paladin.enemyAnim.SetBool("facingRight", true);
            }
    }


    public void PlayerDetection()
    {
        detectionCollider = Physics2D.OverlapCircle(transform.position, sphereRadius, playerAndEnemyLayer);

        if (detectionCollider != null)
        {
            targetGameObject = detectionCollider.gameObject;
            
            if (CheckPlayer())
            {
                paladin.OnAlarmState = true;
                paladin.aIDestinationSetter.target = targetGameObject.transform;
            }
            else if(targetGameObject.CompareTag("Enemy"))
            {
                if (CheckWall())
                {
                    paladin.OnAlarmState = true;
                    paladin.aIDestinationSetter.target = targetGameObject.transform;
                }
            }
        }
        else
        {
            paladin.OnAlarmState = false;
            paladin.aIDestinationSetter.target = null;
        }
    }

    private bool CheckWall()
    {
        RaycastHit2D hit;

        hit = Physics2D.Linecast(transform.position, targetGameObject.transform.position);

        Debug.Log(hit.collider.name);

        if (hit.collider.CompareTag("Obstacle"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool CheckPlayer()
    {
        RaycastHit2D hit;

        hit = Physics2D.Linecast(transform.position, targetGameObject.transform.position, playerAndEnemyLayer);

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
