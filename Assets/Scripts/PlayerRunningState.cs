using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : IState, IChangeVelocity
{
    private Vector3 _direction;

    public void OnEnter(StateController stateController)
    {
        stateController.AnimatorController.SetBool("IsRunning", true);
    }

    public void UpdateState(StateController stateController)
    {
        ChangeVelocity(stateController, stateController.RunningSpeed);

        if (_direction == Vector3.zero)
            stateController.ChangeState(stateController.PlayerIdle);
        else if (!stateController.RunAction.IsPressed())
            stateController.ChangeState(stateController.PlayerWalking);
        else if (stateController.JumpAction.IsPressed())
            stateController.ChangeState(stateController.PlayerJumping);
    }

    public void OnExit(StateController stateController)
    {
        stateController.AnimatorController.SetBool("IsRunning", false);
    }

    public void ChangeVelocity(StateController stateController, float speed)
    {
        Vector2 direction = stateController.MoveAction.ReadValue<Vector2>();
        Vector3 velocity = stateController.RigidBody.velocity;

        velocity.x = direction.x * speed;
        velocity.z = direction.y * speed;

        //stateController.RigidBody.velocity = velocity;
        stateController.RigidBody.AddForce(velocity);
        _direction = velocity;
    }
}
