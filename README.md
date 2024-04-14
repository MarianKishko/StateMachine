State Machine with interface

The main script is StateController and an interface IState.

StateController inheritance with MonoBehavior, has components with Animator and RigidBody (To move player) and one important method ChangeState.

IState has three methods: OnEnter, UpdateState and OnExit.
