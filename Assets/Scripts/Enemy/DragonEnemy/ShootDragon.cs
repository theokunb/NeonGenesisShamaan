using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDragon : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    Transform playerPoint;

    [SerializeField]
    float delay, maxCountFire;

    float time = 0;

    float currentCount = 0;
    void Start()
    {
        playerPoint = GameObject.FindGameObjectWithTag("Player").transform;
    }



    public bool Shoot()
    {
        time += Time.deltaTime;

        if (time >= delay && currentCount <= maxCountFire)
        {
            Fire();
            currentCount++;
            time = 0;
        }

        if (currentCount >= maxCountFire)
        {
            return false;
        }

        return true;
    }

    void Fire()
    {
        GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);

        Bullet bulletComponent = currentBullet.GetComponent<Bullet>();

        var direction = GetBulletDirection();

        bulletComponent.SetDirection(direction);
    }

    public float GetBulletDirection()
    {
        var playerPosition = playerPoint.position;

        var directionVector = new Vector2(playerPosition.x, playerPosition.y) - new Vector2(transform.position.x, transform.position.y);

        var playerDirection = playerPosition.y - transform.position.y;

        float angleToEuler = Vector2.Angle(transform.right, directionVector);

        if (playerDirection < 0)
        {
            angleToEuler = 360 - angleToEuler;
        }

        return angleToEuler;
    }

    public void EndFire()
    {
        currentCount = 0;
        time = 0;
    }
}
