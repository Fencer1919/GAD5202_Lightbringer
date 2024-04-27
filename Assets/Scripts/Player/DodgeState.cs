using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : IState
{
    private Vector2 dashDirection;
    private float dashSpeed = 10;
    private float dashDuration = 0.2f;

    public void EnterState(PlayerController player)
    {
        player.Anim.SetBool("isDodging", true);

        player.hurtBox.enabled = false;

        dashDirection = player.movementVector;
    }

    public void ExitState(PlayerController player)
    {
        player.Anim.SetBool("isDodging", false);

        player.hurtBox.enabled = true;
    }

    public void UpdateState(PlayerController player)
    {
        player.StartCoroutine(HandleDodge(player));

        player.IsAttacking = false;

        if (!player.IsDodging)
        {
            player.ChangeState(new IdleState());
        }
    }


    public IEnumerator HandleDodge(PlayerController player)
    {
        player.transform.Translate(Time.deltaTime * dashDirection * dashSpeed);

        yield return new WaitForSeconds(dashDuration);

        player.IsDodging = false;
    }

}
