using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ShortCuts;

public class PlayerPunchingState : IState
{
    public void OnEnter(StateController stateController)
    {
        stateController.AnimatorController.SetBool("IsWalking", false);
        stateController.AnimatorController.SetBool("IsRunning", false);
        stateController.AnimatorController.SetTrigger("Punch");
    }

    public void UpdateState(StateController stateController)
    {
        if (Horizontal || Vertical)
        {
            if (wasLeftShiftPressed)
                stateController.ChangeState(stateController.PlayerRunning);
            else
                stateController.ChangeState(stateController.PlayerWalking);
        }
        else
            stateController.ChangeState(stateController.PlayerIdle);
    }

    public void OnExit(StateController stateController)
    {
        stateController.AnimatorController.ResetTrigger("Punch");
    }
}
