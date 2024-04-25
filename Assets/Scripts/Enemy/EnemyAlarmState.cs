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
        if (enemy.aIPath.destination != null 
        && (enemy.aIPath.destination - enemy.transform.position).magnitude < enemy.aIPath.endReachedDistance)
        {
            enemy.OnAttackState = true;
            enemy.ChangeState(new EnemyAttackState());
        }

        if (!enemy.characterDetection.isAlarmed && !enemy.OnAttackState)
        {
            enemy.ChangeState(new EnemyIdleState());
        }
    }
}
