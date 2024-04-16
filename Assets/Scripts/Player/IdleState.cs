using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public void EnterState(PlayerController player)
    {
        player.Anim.SetBool("isRunning", false);
    }

    public void ExitState(PlayerController player)
    {
        
    }

    public void UpdateState(PlayerController player)
    {
        if ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position).x > 0)
        {
            player.Anim.SetBool("isLookingRight", true);
        }
        else
        {
            player.Anim.SetBool("isLookingRight", false);
        }

        if (player.IsWalking)
        {
            player.ChangeState(new WalkState());
        }
        else if (player.IsAttacking)
        {
            player.ChangeState(new AttackState());
        }
    }
}
