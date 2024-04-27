using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private float _delay;

    private float _elapsedTime;
    private Animator _animator;

    protected float ElapsedTime => _elapsedTime;
    protected float Delay => _delay;

    private void Start()
    {
        _elapsedTime = _delay;
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    public abstract void Shoot();
    public abstract string GetTriggerName();
    protected void ResetTimer()
    {
        _elapsedTime = 0;
        _animator?.SetTrigger(GetTriggerName());
    }
}
