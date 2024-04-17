using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlarmState : EnemyState
{  
    public void EnterState(MainEnemy enemy)
    {
        Debug.Log("EnemyAlarm Entered");
    }

    public void ExitState(MainEnemy enemy)
    {
        
    }

    public void UpdateState(MainEnemy enemy)
    {
        if (enemy.aIDestinationSetter.target != null 
            && (enemy.aIDestinationSetter.target.position - enemy.transform.position).magnitude < 3)
        {
            enemy.HandleAttack();
        }

        if (!enemy.OnAlarmState)
        {
            enemy.ChangeState(new EnemyIdleState());
        }
    }
}
