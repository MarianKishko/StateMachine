using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Vector2 direction = stateController.MoveAction.ReadValue<Vector2>();

        if (direction != Vector2.zero)
        {
            if (stateController.RunAction.IsPressed())
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
