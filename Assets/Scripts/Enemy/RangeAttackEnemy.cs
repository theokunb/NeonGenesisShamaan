using UnityEngine;

public class RangeAttackEnemy : Enemy
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackDelay;
    [SerializeField] private Bullet _missile;

    Animator _animator;
    SpriteRenderer sprite;
    private float _elapsedTime = 0;

    GameObject player;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

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
        Flip();
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

        _animator.SetTrigger("isAttack");
    }

    private void Flip()
    {
        if (transform.position.x < player.transform.position.x)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            sprite.flipX = true;
        }
        else
        {
            //transform.rotation = Quaternion.Euler(0, 180, 0);
            sprite.flipX = false;
        }
    }
}
