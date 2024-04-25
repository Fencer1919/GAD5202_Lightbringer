using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDetection : MonoBehaviour
{
    [SerializeField] LayerMask targetLayer;
    [SerializeField] LayerMask obstacleLayer;
    [SerializeField] GameObject targetGameObject;
    [SerializeField] private float sphereRadius;

    private RaycastHit2D hit;
    private Collider2D detectionCollider;

    public AIPath aIPath;
    public Animator anim;

    public bool isAlarmed;

    private void Update()
    {
        Detection();
        CheckFacingRight();
    }

    private void CheckFacingRight()
    {
        if (targetGameObject != null && (aIPath.destination - transform.position).x <= 0)
        {
            anim.SetBool("facingRight", false);
        }
        else
        {
            anim.SetBool("facingRight", true);
        }
    }

    private void Detection()
    {
        detectionCollider = Physics2D.OverlapCircle(transform.position, sphereRadius, targetLayer);

        if (detectionCollider != null )
        {
            targetGameObject = detectionCollider.gameObject;

            
            if (CheckWall())
            {
                isAlarmed = true;

                Debug.Log("Target Found!");
                aIPath.destination = targetGameObject.transform.position;
            }
        }
        else
        {
            isAlarmed = false;
            
        }
    }
    private bool CheckWall()
    {
        hit = Physics2D.Linecast(transform.position, targetGameObject.transform.position, obstacleLayer);

        if (hit.collider != null)
        {
                Debug.Log(hit.collider.tag);

            if (hit.collider.CompareTag("Obstacle"))
            {
                return false;
            }
            else
            {
                return true;
            }

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

        if (targetGameObject !=null)
        {
            Gizmos.DrawRay(transform.position, targetGameObject.transform.position - transform.position);

        }

    }

}
