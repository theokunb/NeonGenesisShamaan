using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : BaseEnemy
{
    enum DragonStates
    {
        SelectSpawn,
        WaitState,
        ShowState,
        ShootState,
        HideState
    }

    [SerializeField]
    public List<Transform> spawnDragons;

    Transform currentSpawn;

    [SerializeField]
    float downDistance;
    GameObject player;

    DragonStates state;

    [SerializeField]
    float speed, waitTime, startDistance;

    ShootDragon shoot;

    //Vector3 startPos;

    float time;

    SpriteRenderer sprite;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shoot = GetComponent<ShootDragon>();

        state = DragonStates.SelectSpawn;

        sprite = GetComponentInChildren<SpriteRenderer>();
        //startPos = transform.position;
    }


    void Update()
    {
        float distanceBetween = Vector3.Distance(transform.position, player.transform.position);


        switch (state)
        {
            case DragonStates.SelectSpawn:
                SelectSpawn();
                break;
            case DragonStates.WaitState:
                WaitStateNext(distanceBetween);
                break;
            case DragonStates.ShowState:
                ShowMove();
                break;
            case DragonStates.ShootState:
                Shoot();
                break;
            case DragonStates.HideState:
                HideMove();
                break;
        }

        Flip();
    }

    void SelectSpawn()
    {
        var len = spawnDragons.Count;
        var randomIndex = Random.Range(0, len);

        currentSpawn = spawnDragons[randomIndex];

        state = DragonStates.WaitState;
        transform.position = new Vector2(currentSpawn.position.x, currentSpawn.position.y - downDistance);
    }

    void WaitStateNext(float distanceBetween)
    {
        time += Time.deltaTime;
        if (distanceBetween <= startDistance && time >= waitTime)
        {
            state = DragonStates.ShowState;
            time = 0;
        }
    }

    float distance = 0;
    private void ShowMove()
    {
        transform.Translate(0,speed * Time.deltaTime, 0);
        distance += speed * Time.deltaTime;

        if (distance >= downDistance)
        {
            distance = 0;
            state = DragonStates.ShootState;
        }
    }


    private void HideMove()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
        distance += speed * Time.deltaTime;

        if (distance >= downDistance + 1)
        {
            distance = 0;
            state = DragonStates.SelectSpawn;
        }
    }
    void Shoot()
    {
        bool isShoot = shoot.Shoot();

        if (isShoot == false)
        {
            time += Time.deltaTime;

            if (time >= waitTime)
            {
                state = DragonStates.HideState;
                time = 0;
                shoot.EndFire();
            }
        }
    }

    private void Flip()
    {
        if (transform.position.x < player.transform.position.x)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            sprite.flipX = false;
        }
        else
        {
            //transform.rotation = Quaternion.Euler(0, 180, 0);
            sprite.flipX = true;
        }
    }
}
