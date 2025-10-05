using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : ICharacterState
{
    private PlayerController player;
    private bool checkFlip;
    public MoveState(PlayerController player)
    {
        this.player = player;
    }
    public void EnterState()
    {
       // Debug.Log(player.name + " has entered Move State");
        player.GetAnimator().SetBool("isMoving", true);
    }

    public void UpdateState()
    {
        if (player.GetTarget() != null)
        {
            player.transform.position = MoveToTargetPosition(player.transform.position, player.GetTarget().transform.position);
        }
        checkFlip = FlipImageCheck(player.transform.position, player.GetTarget().transform.position);
        if (checkFlip)
        {
            player.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            player.transform.localEulerAngles = Vector3.zero;
        }
    }

    public void ExitState()
    {
      //  Debug.Log(player.name + " has exited Move State");
        player.GetAnimator().SetBool("isMoving", false);
    }

    private Vector2 MoveToTargetPosition(Vector2 playerPos, Vector2 targetPos)
    {
        if (Vector2.Distance(playerPos, targetPos) <= player.GetGap())
        {
            player.GetAnimator().SetBool("isMoving", false);
            return playerPos;
        }
        return Vector2.MoveTowards(playerPos, targetPos, player.GetSpeed() * Time.deltaTime);
    }

    private bool FlipImageCheck(Vector2 playerPos, Vector2 targetPos)
    {
        return targetPos.x < playerPos.x; //Check target left-right of player
    }
}
