using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BossStates
{
    WaitingState,
    TrackerPersonState,
    HitState,
    DeathState
}


public class BossStateBehavior : MonoBehaviour
{
    Damageble damageble;

    [SerializeField]
    public BossStates state;

    WaitBossState waitBoss;
    TrackerPersonBossState trackerPersonBossState;
    HitBossState hitBossState;
    DeathBossState deathBoss;


    void Start()
    {
        damageble = GetComponent<Damageble>();
        state = BossStates.WaitingState;

        InitState();
    }

    void InitState()
    {
        waitBoss = GetComponent<WaitBossState>();
        trackerPersonBossState = GetComponent<TrackerPersonBossState>();
        hitBossState = GetComponent<HitBossState>();
        deathBoss = GetComponent<DeathBossState>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
        switch (state)
        {
            case BossStates.WaitingState:
                waitBoss.Callback(this);
                break;
            case BossStates.TrackerPersonState:
                trackerPersonBossState.Callback(this);
                break;
            case BossStates.HitState:
                hitBossState.Callback(this);
                break;
            case BossStates.DeathState:
                deathBoss.Callback(this);
                break;
        }

    }

    void UpdateState()
    {
        float hp = damageble.HitPoint;

        if (hp <= 0)
        {
            state = BossStates.DeathState;
        }
    }
}
