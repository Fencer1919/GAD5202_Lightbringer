using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyState
{
    void EnterState(MainEnemy enemy);
    void UpdateState(MainEnemy enemy);
    void ExitState(MainEnemy enemy);
}
