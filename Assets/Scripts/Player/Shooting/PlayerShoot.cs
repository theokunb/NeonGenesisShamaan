using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet, startPoint, body;

    [SerializeField]
    Animator cameraShake;

    [SerializeField]
    float delay;

    Transform playerTransform;

    float time = 0;

    void Start()
    {
        playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (Input.GetMouseButton(0) && time >= delay)
        {
            Fire();
            time = 0;
        }
    }

    public void Fire()
    {
        GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);

        Bullet bulletComponent = currentBullet.GetComponent<Bullet>();

        bulletComponent.SetDirection(GetBulletDirection());

        //cameraShake.SetTrigger("Fire");
    }

    public float GetBulletDirection()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var directionVector = new Vector2(mousePosition.x, mousePosition.y) - new Vector2(playerTransform.position.x, playerTransform.position.y);

        var mouseDirection = mousePosition.y - playerTransform.position.y;

        float angleToEuler = Vector2.Angle(playerTransform.right, directionVector);

        if (mouseDirection < 0)
        {
            angleToEuler = 360 - angleToEuler;
        }

        return angleToEuler;
    }
}
