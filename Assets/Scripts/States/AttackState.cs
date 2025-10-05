using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class AttackState : ICharacterState
{
    private PlayerController player;
    public AttackState(PlayerController player)
    {
        this.player = player;
    }
    public void EnterState()
    {
      //  Debug.Log(player.name + " has entered Attack State");
        player.GetAnimator().SetBool("isAttacking", true);
    }

    public void ExitState()
    {
     //   Debug.Log(player.name + " has exited Attack State");
        player.GetAnimator().SetBool("isAttacking", false);
    }

    public void UpdateState()
    {
        
    }

 
}
