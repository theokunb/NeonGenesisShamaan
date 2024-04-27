using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeEnemyMovement : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //shoot = GetComponent<EnemyShoot>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        Flip();
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
