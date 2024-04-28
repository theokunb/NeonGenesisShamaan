using UnityEngine;

public class MeeleeWeapon : Weapon
{
    [SerializeField] private float _damage, radiusAttack;

    public override string GetTriggerName()
    {
        return "Hit";
    }

    public override void Shoot()
    {
        if(ElapsedTime < Delay)
        {
            return;
        }

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
