using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private float _delay;

    private float _elapsedTime;

    protected float ElapsedTime => _elapsedTime;
    protected float Delay => _delay;

    private void Start()
    {
        _elapsedTime = _delay;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    public abstract void Shoot();
    protected void ResetTimer()
    {
        _elapsedTime = 0;
    }
}
