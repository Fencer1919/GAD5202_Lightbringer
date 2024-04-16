using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public void EnterState(MainEnemy enemy)
    {
        
    }

    public void ExitState(MainEnemy enemy)
    {
        
    }

    public void UpdateState(MainEnemy enemy)
    {
        if (enemy.OnAlarmState)
        {
            enemy.ChangeState(new EnemyAlarmState());
        }
    }
}
