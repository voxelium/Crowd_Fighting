using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Hand Ability", menuName = "Player/Abilities/Hand", order = 51)]

public class HandAbility : Ability
{
    [SerializeField] private float _attackForce;
    [SerializeField] private float _useFullTime;

    private AttackState _state;
    private Coroutine coroutine;

    public override event UnityAction AbilityEnded;

    public override void UseAbility(AttackState attack)
    {
        if (coroutine != null)
        {
            Reset();
        }
        _state = attack;

        coroutine = _state.StartCoroutine(Attack(_state));

        _state.CollisionDetected += OnPlayerAttack;
    }

    private void Reset()
    {
        _state.Rigidbody.velocity = Vector3.zero;
        _state.StopCoroutine(coroutine);
        coroutine = null;
        _state.CollisionDetected -= OnPlayerAttack;
    }

    private void OnPlayerAttack(iDamageable damageable)
    {
        if (damageable.ApplyDamage(_state.Rigidbody, _attackForce) == false)
        {
            return;
        }
        _state.Rigidbody.velocity /= 2;

    }

    private IEnumerator Attack(AttackState state)
    {
        float time = _useFullTime;

        while (time > 0)
        {
            state.Rigidbody.velocity = state.Rigidbody.velocity.normalized * _attackForce;
            time -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Reset();
        AbilityEnded?.Invoke();
    }

}
