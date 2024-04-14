using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [HideInInspector] public Animator AnimatorController;

    private Rigidbody _rigidBody;

    public Rigidbody RigidBody => _rigidBody;

    [Header("Basic Movement")]
    public float Speed;
    public float RunningSpeed;

    public PlayerIdleState PlayerIdle = new PlayerIdleState();
    public PlayerWalkingState PlayerWalking = new PlayerWalkingState();
    public PlayerRunningState PlayerRunning = new PlayerRunningState();
    public PlayerPunchingState PlayerPunching = new PlayerPunchingState();
    public PlayerJumpState PlayerJumping = new PlayerJumpState();

    private IState _currentState;

    private void Start()
    {
        AnimatorController = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody>();

        _currentState = PlayerIdle;
    }

    private void Update()
    {
        if (_currentState != null)
            _currentState.UpdateState(this);
    }

    public void ChangeState(IState newState)
    {
        if (_currentState != null)
            _currentState.OnExit(this);

        _currentState = newState;
        _currentState.OnEnter(this);
    }
}

public interface IState 
{
    public void OnEnter(StateController stateController);

    public void UpdateState(StateController stateController);

    public void OnExit(StateController stateController);
}
