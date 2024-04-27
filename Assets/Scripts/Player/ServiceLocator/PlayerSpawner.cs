using System;
using UnityEngine;

public class PlayerSpawner : BaseMonoBeh, IService
{
    [SerializeField] private Transform _spawnPosition;

    public GameObject player;

    public event Action<GameObject> PlayerSpawned;

    public override void BaseAwake()
    {
        base.BaseAwake();
        ServiceLocator.Instance.Register(this);
    }

    public override void BaseStart()
    {
        var createdPlayer = Instantiate(player, _spawnPosition.position, Quaternion.identity);
        PlayerSpawned?.Invoke(createdPlayer);
    }
}
