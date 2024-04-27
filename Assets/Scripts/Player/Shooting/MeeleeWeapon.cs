using UnityEngine;

public class MeeleeWeapon : Weapon
{
    [SerializeField] private float _damage, radiusAttack;

    private Animator _animator;


    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public override void Shoot()
    {
        if(ElapsedTime < Delay)
        {
            return;
        }

        _animator.SetTrigger("Hit");

        var colliders = Physics2D.CircleCast(transform.position, radiusAttack, -transform.right);

        if(colliders.collider.TryGetComponent(out BaseEnemy enemy))
        {
            if(enemy.TryGetComponent(out Damageble damageble))
            {
                damageble.Damage(_damage);
            }
        }

        ResetTimer();
    }
}
