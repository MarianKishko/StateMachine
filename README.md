State Machine with interface

The main script is StateController and an interface IState.

StateController inheritance with MonoBehavior, has components with Animator and RigidBody (To move player) and one important method ChangeState.

IState has three methods: OnEnter, UpdateState and OnExit.

How it all works?

there is IState variable _currentState that value is classes that inheriatance with IState.
Update function runs UpdateState method of _currentState.
When the state changes, then the value of _currentState changes in ChangeState and activating OnEnter.

How to use it?
1. Create public variable of class that inheritance with IState.
2. Implement all methods of IState.
3. Do whatever you want.

