using System;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator _animator;
    private Damageble _damageble;

    public event Action DieAnimationEndedEvent;

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        _damageble = GetComponentInParent<Damageble>();
        _damageble.OnCharacterDeadEvent += OnPlayerDead;
    }

    private void OnPlayerDead(object obj)
    {
        _animator.SetTrigger("Die");
    }

    public void Test()
    {
        Debug.Log("test");
    }

    public void AnimationEnded()
    {
        DieAnimationEndedEvent?.Invoke();
    }
}
