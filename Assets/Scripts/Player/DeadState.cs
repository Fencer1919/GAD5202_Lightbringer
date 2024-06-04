using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    public static event Action onDead;

    public void EnterState(PlayerController player)
    {
        onDead.Invoke();
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
