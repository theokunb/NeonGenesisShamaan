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
    }

    public override void BaseStart()
    {
        var createdPlayer = Instantiate(player, _spawnPosition.position, Quaternion.identity);
        PlayerSpawned?.Invoke(createdPlayer);

        if(createdPlayer.TryGetComponent(out Damageble damageble))
        {
            damageble.OnCharacterDeadEvent += OnPlayerDied;
        }
    }

    private void OnPlayerDied(object obj)
    {
        var loseView = ServiceLocator.Instance.Get<LoseView>();
        loseView.Show();
    }
}
