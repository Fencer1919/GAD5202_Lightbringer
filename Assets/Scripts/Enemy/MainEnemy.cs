using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainEnemy : MonoBehaviour
{
    public AIDestinationSetter aIDestinationSetter;
    public AIPath aIPath;

    public Animator enemyAnim;


    private EnemyState currentEnemyState;

    public event Action OnEnemyAttack;


    private bool onAlarmState;
    private bool onAttackState;
    public bool OnAlarmState { get => onAlarmState; set => onAlarmState = value; }
    public bool OnAttackState { get => onAttackState; set => onAttackState = value; }

    void Start()
    {
        currentEnemyState = new EnemyIdleState();
        currentEnemyState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentEnemyState.UpdateState(this);
    }
    public void ChangeState(EnemyState newState)
    {
        currentEnemyState.ExitState(this);
        currentEnemyState = newState;
        currentEnemyState.EnterState(this);
    }

    public void HandleEnemyAttack()
    {
        OnEnemyAttack?.Invoke();
    }
}
