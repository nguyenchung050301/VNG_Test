using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : ICharacterState
{
    private PlayerController player;
    public DieState(PlayerController player)
    {
        this.player = player;
    }

    public void EnterState()
    {
       // Debug.Log("" + player.name + " has entered Die State");
        player.GetAnimator().CrossFade("Die", 0f);
       // player.GetAnimator().SetBool("isDead", true);
    }

    public void ExitState()
    {
     //   player.GetAnimator().SetBool("isDead", false);
    }

    public void UpdateState()
    {
   
    }

   
}
