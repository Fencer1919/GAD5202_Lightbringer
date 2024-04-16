using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IState
{
    public void EnterState(PlayerController player)
    {
        player.Anim.SetBool("isRunning", true);
    }

    public void ExitState(PlayerController player)
    {
        
    }

    public void UpdateState(PlayerController player)
    {
        player.HandleMovement();

        if (player.MovementVector.x >= 0)
        {
            player.Anim.SetBool("isLookingRight", true);
        }
        else
        {
            player.Anim.SetBool("isLookingRight", false);
        }



        if (!player.IsWalking)
        {
            player.ChangeState(new IdleState());
        }
        else if(player.IsDodging)
        {
            player.ChangeState(new DodgeState());
        }
        else if (player.IsAttacking)
        {
            player.ChangeState(new AttackState());
        }
    }
}
