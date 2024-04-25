using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinAlarmState : PaladinState
{  
    
    public void EnterState(MainPaladin paladin)
    {
        Debug.Log("EnemyAlarm Entered");

        paladin.companionAnim.SetBool("isWalking", true);
    }

    public void ExitState(MainPaladin paladin)
    {
        paladin.companionAnim.SetBool("isWalking", false);
    }

    public void UpdateState(MainPaladin paladin)
    {
        if (paladin.aIDestinationSetter.target != null 
            && (paladin.aIDestinationSetter.target.position - paladin.transform.position).magnitude < paladin.stoppingDistance 
            && !paladin.aIDestinationSetter.target.CompareTag("Player"))
        {   
            Debug.Log("PALADIN STOPPING DISTANCE");

            paladin.OnAttackState = true;
            paladin.ChangeState(new PaladinAttackState());
        }

        if (!paladin.OnAlarmState && !paladin.OnAttackState)
        {
            paladin.ChangeState(new PaladinIdleState());
        }
    }
}
