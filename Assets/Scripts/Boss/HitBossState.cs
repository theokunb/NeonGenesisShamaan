using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBossState : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    float waitHitAnimSecond = 0.4f;

    [SerializeField]
    float hitDistance = 1, damage = 10;

    private Transform player;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    public void Callback(BossStateBehavior bossStateBehavior)
    {
        print("HitBossState");

        animator.SetTrigger("isHit");
        StartCoroutine(BossHit(bossStateBehavior));
    }

    IEnumerator BossHit(BossStateBehavior bossStateBehavior)
    {
        yield return new WaitForSeconds(waitHitAnimSecond);

        Hit(bossStateBehavior);
    }

    public void Hit(BossStateBehavior bossStateBehavior)
    {
        var distence = Vector2.Distance(transform.position, player.transform.position);
        if (distence <= hitDistance)
        {
            player.GetComponent<Damageble>().Damage(damage);
            bossStateBehavior.state = BossStates.TrackerPersonState;
        }

        bossStateBehavior.state = BossStates.TrackerPersonState;
    }

}
