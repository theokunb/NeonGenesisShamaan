using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSensor : MonoBehaviour
{
    [SerializeField]
    WaitBossState waitBossState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            waitBossState.PlayerIsRoom();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            waitBossState.PlayerIsRoom();
        }
    }
}
