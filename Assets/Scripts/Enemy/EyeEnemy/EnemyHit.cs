using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private GameObject player;
    public float damage = 10f;
    Damageble damageble;

    [SerializeField]
    bool playerIsHitZone = false;

    [SerializeField]
    float delay;

    float time = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        damageble = player.GetComponent<Damageble>();
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (playerIsHitZone && time >= delay)
        {
            Hit();
            time = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIsHitZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIsHitZone = false;
        }
    }

    public void Hit()
    {
        damageble?.Damage(damage);
    }
}
