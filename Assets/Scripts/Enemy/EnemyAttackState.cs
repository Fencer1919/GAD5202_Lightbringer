using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public void EnterState(MainEnemy enemy)
    {
        Debug.Log("enemyAttacked");

        enemy.aIPath.maxSpeed = 0;

        enemy.HandleEnemyAttack();

        enemy.StartCoroutine(EnemyAttack(enemy));


    }

    public void ExitState(MainEnemy enemy)
    {
        Debug.Log("enemyAttack finished");

        enemy.aIPath.maxSpeed = 4;        

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
