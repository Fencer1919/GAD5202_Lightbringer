using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public void EnterState(MainEnemy enemy)
    {

        enemy.aIPath.maxSpeed = 0;

        if(enemy.enemyHitBox.HitboxCollider != null)
        {
            enemy.enemyHitBox.HitboxCollider.enabled = true;
        }

        enemy.HandleEnemyAttack();

        enemy.StartCoroutine(EnemyAttack(enemy));

        enemy.enemyAnim.SetBool("isAttacking", true);




    }

    public void ExitState(MainEnemy enemy)
    {
        Debug.Log("enemyAttack finished");

        if(enemy.enemyHitBox.HitboxCollider != null)
        {
            enemy.enemyHitBox.HitboxCollider.enabled = false;
        }

        enemy.aIPath.maxSpeed = 4;    

        enemy.enemyAnim.SetBool("isAttacking", false);    

    }

    public void UpdateState(MainEnemy enemy)
    {

    }

    public IEnumerator EnemyAttack(MainEnemy enemy)
    {
        yield return new WaitForSeconds(1);

        enemy.ChangeState(new EnemyAlarmState());
    }
}
