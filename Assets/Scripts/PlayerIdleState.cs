using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IState
{
    public void OnEnter(StateController stateController)
    {
        stateController.AnimatorController.SetBool("IsWalking", false);
        stateController.AnimatorController.SetBool("IsRunning", false);
    }

    public void UpdateState(StateController stateController)
    {
        Vector2 direction = stateController.MoveAction.ReadValue<Vector2>();

        if (direction != Vector2.zero)
        {
            if (stateController.RunAction.IsPressed())
                stateController.ChangeState(stateController.PlayerRunning);
            else
                stateController.ChangeState(stateController.PlayerWalking);
        }
        else if (stateController.PunchAction.IsPressed())
            stateController.ChangeState(stateController.PlayerPunching);
        else if (stateController.JumpAction.IsPressed())
            stateController.ChangeState(stateController.PlayerJumping);
    }

    public void OnExit(StateController stateController) 
    { 
    }
}
