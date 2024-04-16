using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemy : MonoBehaviour
{
    private EnemyState currentEnemyState;

    private bool onAlarmState;

    public Vector3 targetLocation;

    public bool OnAlarmState { get => onAlarmState; set => onAlarmState = value; }

    public void HandleEnemyMovement()
    {
        transform.Translate(Time.deltaTime * targetLocation * 5);
    }

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
}
