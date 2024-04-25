using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PaladinState
{
    void EnterState(MainPaladin paladin);
    void UpdateState(MainPaladin paladin);
    void ExitState(MainPaladin paladin);
}
