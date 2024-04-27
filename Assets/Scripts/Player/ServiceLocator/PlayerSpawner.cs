using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : BaseMonoBeh
{
    public GameObject player;

    public override void BaseStart()
    {
        Instantiate(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
