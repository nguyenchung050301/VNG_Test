using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : ICharacterState
{
    private PlayerController player;
    public IdleState(PlayerController player)
    {
        this.player = player;
    }
    public void EnterState()
    {
      //  Debug.Log(player.name + " has entered Idle State");
        player.GetAnimator().SetBool("isIdling", true);
    }

    public void UpdateState()
    {
      
    }

    public void ExitState()
    {
      //  Debug.Log(player.name + " has exited Idle State");
        player.GetAnimator().SetBool("isIdling", false);
    }

}
