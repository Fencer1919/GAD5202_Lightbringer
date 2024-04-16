using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : IState
{   
    public void EnterState(PlayerController player)
    {

    }

    public void ExitState(PlayerController player)
    {

    }

    public void UpdateState(PlayerController player)
    {
        player.StartCoroutine(player.HandleDodge());

        player.IsAttacking = false;


        if (!player.IsDodging)
        {
            player.ChangeState(new IdleState());
        }
    }
}
