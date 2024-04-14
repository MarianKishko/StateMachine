using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ShortCuts;

public class PlayerRunningState : IState
{
    private Vector3 _direction;

    public void OnEnter(StateController stateController)
    {
        stateController.AnimatorController.SetBool("IsRunning", true);
    }

    public void UpdateState(StateController stateController)
    {
        _direction = Camera.main.transform.TransformDirection(new Vector3(Input.GetAxisRaw("Horizontal") * stateController.RunningSpeed, 0, Input.GetAxisRaw("Vertical") * stateController.RunningSpeed));

        stateController.RigidBody.velocity = _direction;

        if (!Horizontal && !Vertical)
            stateController.ChangeState(stateController.PlayerIdle);
        else if (!wasLeftShiftPressed)
            stateController.ChangeState(stateController.PlayerWalking);
        else if (Jump)
            stateController.ChangeState(stateController.PlayerJumping);
    }

    public void OnExit(StateController stateController)
    {
        stateController.AnimatorController.SetBool("IsRunning", false);
    }
}
