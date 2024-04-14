using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ShortCuts;

public class PlayerIdleState : IState
{
    public void OnEnter(StateController stateController)
    {
        stateController.AnimatorController.SetBool("IsWalking", false);
        stateController.AnimatorController.SetBool("IsRunning", false);
    }

    public void UpdateState(StateController stateController)
    {
        Debug.Log("Update - Idle");

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (wasLeftShiftPressed)
                stateController.ChangeState(stateController.PlayerRunning);
            else
                stateController.ChangeState(stateController.PlayerWalking);
        }
        else if (isAttackButtonPressed)
            stateController.ChangeState(stateController.PlayerPunching);
        else if (Jump)
            stateController.ChangeState(stateController.PlayerJumping);
    }

    public void OnExit(StateController stateController) 
    { 
    }
}
