using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerPersonBossState : MonoBehaviour
{
    public float speed = 10;
    private Transform player;

    [SerializeField]
    float stopDistance = 1;

    // Start is called before the first frame update
    void Start()
    {
        
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
        print("TrackerPersonBossState");
        var distence = Vector2.Distance(transform.position, player.transform.position);
        if (distence > stopDistance)
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        else
        {
            bossStateBehavior.state = BossStates.HitState;
        }
    }
}
