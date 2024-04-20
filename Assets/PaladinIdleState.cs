using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinIdleState : PaladinState
{
    public void EnterState(MainPaladin paladin)
    {
        Debug.Log("Entered Enemy Idle");
    }

    public void ExitState(MainPaladin paladin)
    {
        
    }

    public void UpdateState(MainPaladin paladin)
    {
        if (paladin.OnAlarmState)
        {
            paladin.ChangeState(new PaladinAlarmState());
        }
    }
}
