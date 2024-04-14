using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ShortCuts;

public class PlayerWalkingState : IState
{
    private Vector3 _direction;

    public void OnEnter(StateController stateController)
    {
        Debug.Log("Enter - Walk");

        stateController.AnimatorController.SetBool("IsWalking", true);
    }

    public void UpdateState(StateController stateController)
    {
        Debug.Log("Update - Walk");
        
        _direction = Camera.main.transform.TransformDirection(new Vector3(Input.GetAxisRaw("Horizontal") * stateController.Speed, 0, Input.GetAxisRaw("Vertical") * stateController.Speed));

        stateController.RigidBody.velocity = _direction;

        if (!Horizontal && !Vertical)
            stateController.ChangeState(stateController.PlayerIdle);
        else if (wasLeftShiftPressed)
            stateController.ChangeState(stateController.PlayerRunning);
        else if (Jump)
            stateController.ChangeState(stateController.PlayerJumping);
    }

    public void OnExit(StateController stateController) 
    {
        Debug.Log("Exit - Walk");

        stateController.AnimatorController.SetBool("IsWalking", false);
    }
}
