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

    private void Start()
    {
        aimTransform = GetComponent<Transform>();

        player.onAttack += Player_onAttack;
        

    }

    private void Player_onAttack()
    {       
        hitBoxDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(hitBoxDirection.y, hitBoxDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            collider.GetComponent<EnemyHealth>().TakeDamage(meleeDamage);;

            if (collider.GetComponent<EnemyHealth>().IsDead)
            {
                oathTracker.currentOathValue -= 1;
            }
            

        }
    }

}
