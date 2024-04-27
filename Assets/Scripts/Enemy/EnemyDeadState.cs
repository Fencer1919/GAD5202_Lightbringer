using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState
{
    public void EnterState(MainEnemy enemy)
    {
        if (enemy.enemyHealth.IsDead)
        {
            enemy.StopAllCoroutines();
        }

        enemy.hurtBox.enabled = false;

        enemy.aIPath.maxSpeed = 0;

        enemy.enemyAnim.SetBool("isDead", true);
    }

    public void ExitState(MainEnemy enemy)
    {

    }

    public void UpdateState(MainEnemy enemy)
    {

    }
}
