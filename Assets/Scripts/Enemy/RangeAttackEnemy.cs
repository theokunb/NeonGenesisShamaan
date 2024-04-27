using UnityEngine;

public class RangeAttackEnemy : Enemy
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackDelay;
    [SerializeField] private Bullet _missile;

    private float _elapsedTime = 0;

    protected override void Update()
    {
        base.Update();

        _elapsedTime += Time.deltaTime;

        if(_attackDelay < _elapsedTime)
        {
            var direction = Target.transform.position - _shootPoint.position;

            if (direction.magnitude > _attackDistance)
            {
                return;
            }

            _elapsedTime = 0;
            Attack();
        }
    }

    public override void Attack()
    {
        var direction = Target.transform.position - _shootPoint.transform.position;
        var angle = Vector2.Angle(_shootPoint.right, direction);

        var yOffset = Target.transform.position.y - _shootPoint.position.y;

        if(yOffset < 0)
        {
            angle = 360 - angle;
        }

        var missile = Instantiate(_missile, _shootPoint.position, Quaternion.identity);
        missile.SetDirection(angle);
    }
}
