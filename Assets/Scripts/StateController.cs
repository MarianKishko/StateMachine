using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StateController : MonoBehaviour
{
    [HideInInspector] public Animator AnimatorController;

    private Rigidbody _rigidBody;

    public Rigidbody RigidBody => _rigidBody;

    private PlayerInputActions _playerControls;

    public InputAction MoveAction;
    public InputAction JumpAction;
    public InputAction RunAction;
    public InputAction PunchAction;

    [Header("Basic Movement")]
    public float Speed;
    public float RunningSpeed;

    public PlayerIdleState PlayerIdle = new PlayerIdleState();
    public PlayerWalkingState PlayerWalking = new PlayerWalkingState();
    public PlayerRunningState PlayerRunning = new PlayerRunningState();
    public PlayerPunchingState PlayerPunching = new PlayerPunchingState();
    public PlayerJumpState PlayerJumping = new PlayerJumpState();

    private IState _currentState;

    private void Awake()
    {
        _playerControls = new PlayerInputActions();
    }

    private void Start()
    {
        AnimatorController = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody>();

        _currentState = PlayerIdle;
    }

    private void OnEnable()
    {
        MoveAction = _playerControls.Player.Move;
        MoveAction.Enable();

        _playerControls.Player.Look.Enable();

        PunchAction = _playerControls.Player.Fire;
        PunchAction.Enable();

        JumpAction = _playerControls.Player.Jump;
        JumpAction.Enable();

        RunAction = _playerControls.Player.Run;
        RunAction.Enable();
    }

    private void OnDisable()
    {
        MoveAction = _playerControls.Player.Move;
        MoveAction.Disable();

        _playerControls.Player.Look.Disable();

        PunchAction = _playerControls.Player.Fire;
        PunchAction.Disable();

        JumpAction = _playerControls.Player.Jump;
        JumpAction.Disable();

        RunAction = _playerControls.Player.Run;
        RunAction.Disable();
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