using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitBossState : MonoBehaviour
{
    Animator animator;
    bool playerIsRoom;


    [SerializeField]
    float waitSecond = 1;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        
    }

    public void Callback(BossStateBehavior bossStateBehavior)
    {
        if (playerIsRoom == false)
            return;

        animator.SetTrigger("isTransform");
        bossStateBehavior.state = BossStates.TrackerPersonState;
        //StartCoroutine(WaitForAnimationTransformation(bossStateBehavior));
    }

    IEnumerator WaitForAnimationTransformation(BossStateBehavior bossStateBehavior)
    {
        yield return new WaitForSeconds(waitSecond);
        animator.SetTrigger("isTransform");
        bossStateBehavior.state = BossStates.TrackerPersonState;
    }

    public void PlayerIsRoom()
    {
        playerIsRoom = true;
    }
}
