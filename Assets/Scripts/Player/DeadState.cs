using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    public void EnterState(PlayerController player)
    {
        Debug.Log("DEADSTATE");
        player.Anim.SetBool("isDead", true);
        player.rb.simulated = false;
    }

    public void ExitState(PlayerController player)
    {
        
    }

    public void UpdateState(PlayerController player)
    {

    }
}
