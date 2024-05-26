using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : MonoBehaviour
{
    public GameObject target;
    public Vector3 bulletDirection;

    public float bulletSpeed;


    public float rangedEnemyDamage;

    void Start()
    {   
        target = GameObject.FindGameObjectWithTag("Player");

        bulletDirection = (target.transform.position - transform.position).normalized;

    }

    void Update()
    {
        transform.position += bulletSpeed * Time.deltaTime * bulletDirection;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerHealth hit))
        {
            hit.TakeDamage(rangedEnemyDamage);

            Destroy(gameObject);
        }
    }
}
