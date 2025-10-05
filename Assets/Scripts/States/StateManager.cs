using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager
{
    /// Player States
    private ICharacterState curentState;
    ///

    public void ChangeState(ICharacterState newState)
    {
        curentState?.ExitState();
        curentState = newState;
        curentState?.EnterState();
    }
    
    public void UpdateState()
    {
        curentState?.UpdateState();
    }
    public ICharacterState GetCurrentState() => curentState;
}
