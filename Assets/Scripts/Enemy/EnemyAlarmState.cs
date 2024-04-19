using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlarmState : EnemyState
{  
    

    public void EnterState(MainEnemy enemy)
    {
        Debug.Log("EnemyAlarm Entered");

        enemy.enemyAnim.SetBool("isWalking", true);
    }

    public void ExitState(MainEnemy enemy)
    {
        enemy.enemyAnim.SetBool("isWalking", false);
    }

    public void UpdateState(MainEnemy enemy)
    {
        if (enemy.aIDestinationSetter.target != null 
            && (enemy.aIDestinationSetter.target.position - enemy.transform.position).magnitude < enemy.stoppingDistance)
        {
            enemy.OnAttackState = true;
            enemy.ChangeState(new EnemyAttackState());
        }

        if (!enemy.OnAlarmState && !enemy.OnAttackState)
        {
            enemy.ChangeState(new EnemyIdleState());
        }
    }
}
