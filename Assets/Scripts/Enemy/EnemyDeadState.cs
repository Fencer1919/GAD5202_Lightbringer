using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState
{
    public void EnterState(MainEnemy enemy)
    {
        enemy.rb.simulated = false;
        enemy.enemyHitBox.enabled = false;
    }

    public void ExitState(MainEnemy enemy)
    {

    }

    public void UpdateState(MainEnemy enemy)
    {

    }
}
