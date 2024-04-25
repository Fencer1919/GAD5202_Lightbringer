using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainPaladin : MonoBehaviour
{
    public AIDestinationSetter aIDestinationSetter;
    public AIPath aIPath;

    public PaladinWeaponHitBox paladinWeaponHitBox;

    public float stoppingDistance;

    public Animator companionAnim;


    private PaladinState currentPaladinState;

    public event Action OnPaladinAttack;


    private bool onAlarmState;
    private bool onAttackState;
    public bool OnAlarmState { get => onAlarmState; set => onAlarmState = value; }
    public bool OnAttackState { get => onAttackState; set => onAttackState = value; }

    void Start()
    {
        currentPaladinState = new PaladinIdleState();
        currentPaladinState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentPaladinState.UpdateState(this);
    }
    public void ChangeState(PaladinState newState)
    {
        currentPaladinState.ExitState(this);
        currentPaladinState = newState;
        currentPaladinState.EnterState(this);
    }

    public void HandleEnemyAttack()
    {
        OnPaladinAttack?.Invoke();
    }
}
