using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidBody;

    public Animator AnimatorController => _animator;
    public Rigidbody RigidBody => _rigidBody;

    public float Speed;
    public float RunningSpeed;
}
