using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : PlayerState
{
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedRatio;

    private void OnEnable()
    {
        _playerInput.DirectionChanged += OnDirectionChanged;
    }

    private void OnDisable()
    {
        _playerInput.DirectionChanged -= OnDirectionChanged;
    }

    private void OnDirectionChanged(Vector2 direction)
    {
        Rigidbody.velocity = new Vector3(direction.x, 0, direction.y) * _speedRatio;

        if (Rigidbody.velocity.magnitude > _maxSpeed)
        {
            Rigidbody.velocity *= _maxSpeed / Rigidbody.velocity.magnitude;
        }

        if (Rigidbody.velocity.magnitude != 0)
        {
            Rigidbody.MoveRotation(Quaternion.LookRotation(Rigidbody.velocity, Vector3.up));
        }
    }

}
