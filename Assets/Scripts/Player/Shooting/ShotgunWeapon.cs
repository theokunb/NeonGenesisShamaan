using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : Weapon
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private ShootPoint _shootPoint;
    public override void Shoot()
    {
        if (ElapsedTime >= Delay)
        {
            var rotation = Quaternion.Euler(0, 0, GetBulletDirection());

            var currentBullet = Instantiate(_bullet, transform.position, rotation);

            ResetTimer();
        }
    }

    public float GetBulletDirection()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var directionVector = new Vector2(mousePosition.x, mousePosition.y) - new Vector2(_shootPoint.transform.position.x, _shootPoint.transform.position.y);

        var mouseDirection = mousePosition.y - _shootPoint.transform.position.y;

        float angleToEuler = Vector2.Angle(_shootPoint.transform.right, directionVector);

        if (mouseDirection < 0)
        {
            angleToEuler = 360 - angleToEuler;
        }

        return angleToEuler;
    }
}
