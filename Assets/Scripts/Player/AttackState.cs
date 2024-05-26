using System;
using UnityEngine;

public class AttackState : IState
{
    private float nextMeleeAttackTime = 0f;

    private float rangedAttackTime = 0f;


    [Header("HandleAttack")]
    public float attackRate = 1f;
    public float rangedAttackRate = 2f;

    public GameObject rangedObj;

    public static event Action onAttack;

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
            player.MovementSpeed = 0f;

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

            HandleMeleeAttack();
            nextMeleeAttackTime = Time.time + 1f / attackRate;            
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

            HandleRangedAttack(player);

            rangedAttackTime = Time.time + 1f / rangedAttackRate;
        }

        if (!player.IsAttacking)
        {
            player.ChangeState(new IdleState());
        }
    }
    public void HandleMeleeAttack()
    {
        onAttack?.Invoke();
    }

    public void HandleRangedAttack(PlayerController player)
    {
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) 
            + Vector3.forward * 10 + Vector3.up * 1.2f;

        rangedObj = UnityEngine.Object.Instantiate(player.rangedAttackObject, spawnPosition, Quaternion.identity, player.transform);
    }
}
