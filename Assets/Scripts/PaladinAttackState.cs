using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinAttackState : PaladinState
{
    public void EnterState(MainPaladin paladin)
    {
        Debug.Log("enemyAttacked");

        paladin.aIPath.maxSpeed = 0;

        paladin.paladinWeaponHitBox.HitboxCollider.enabled = true;

        paladin.HandleEnemyAttack();

        paladin.StartCoroutine(EnemyAttack(paladin));


    }

    public void ExitState(MainPaladin paladin)
    {

        paladin.paladinWeaponHitBox.HitboxCollider.enabled = false;

        paladin.aIPath.maxSpeed = 4;        

    }

    public void UpdateState(MainPaladin paladin)
    {

    }

    public IEnumerator EnemyAttack(MainPaladin paladin)
    {
        yield return new WaitForSeconds(1);

        paladin.ChangeState(new PaladinAlarmState());
    }
}
