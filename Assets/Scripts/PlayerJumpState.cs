using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ShortCuts;

public class PlayerJumpState : IState
{
    public void OnEnter(StateController stateController)
    {
        stateController.AnimatorController.SetTrigger("Jump");
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
        stateController.AnimatorController.ResetTrigger("Jump");
    }
}
