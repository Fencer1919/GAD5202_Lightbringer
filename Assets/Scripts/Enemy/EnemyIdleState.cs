using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public void EnterState(MainEnemy enemy)
    {
        Debug.Log("Entered Enemy Idle");
    }

    public void ExitState(MainEnemy enemy)
    {
        
    }

    public void UpdateState(MainEnemy enemy)
    {
        if (enemy.characterDetection.isAlarmed)
        {
            enemy.ChangeState(new EnemyAlarmState());
        }
    }
}
