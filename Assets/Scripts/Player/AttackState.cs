using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private float nextMeleeAttackTime = 0f;

    private float rangedAttackTime = 0f;
    
    public void EnterState(PlayerController player)
    {
        player.MovementSpeed = 1.5f;

        if (player.meleeAttackInput)
        {
            player.PlayerWeapon.SetActive(true);
            player.Anim.SetBool("isAttackingMelee", true);
        }
        else if (player.rangedAttackInput)
        {
            player.Anim.SetBool("isSmiting", true);
        }


    }

    public void ExitState(PlayerController player)
    {
        player.MovementSpeed = 5;

        player.PlayerWeapon.SetActive(false);

        player.Anim.SetBool("isAttackingMelee", false);
        player.Anim.SetBool("isSmiting", false);

    }

    public void UpdateState(PlayerController player)
    {
        player.HandleMovement();

        //not the best solution
        player.IsDodging = false;

        //Holding Mouse Button to continue attacking

        if (player.meleeAttackInput && Time.time >= nextMeleeAttackTime)
        {
            //setting animation variable for character animation based on mouse position 
            if ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position).x > 0)
            {
                player.Anim.SetBool("isLookingRight", true);
            }
            else
            {
                player.Anim.SetBool("isLookingRight", false);
            }

            Debug.Log("attack!");

            player.HandleMeleeAttack();
            nextMeleeAttackTime = Time.time + 1f / player.attackRate;            
        }

        //Ranged HandleAttack

        if (player.rangedAttackInput && Time.time >= rangedAttackTime)
        {
            if ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position).x > 0)
            {
                player.Anim.SetBool("isLookingRight", true);
            }
            else
            {
                player.Anim.SetBool("isLookingRight", false);
            }

            player.HandleRangedAttack();

            rangedAttackTime = Time.time + 1f / player.rangedAttackRate;
        }

        if (!player.IsAttacking)
        {
            player.ChangeState(new IdleState());
        }
    }

}
