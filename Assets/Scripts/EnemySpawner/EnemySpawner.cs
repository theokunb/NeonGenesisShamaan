using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : BaseMonoBeh, IService
{
    private SpawnPoint[] _spawnPoints;
    private List<Enemy> _enemies;
    private PlayerSpawner _playerSpawner;
    private Player _target;

    public override void BaseAwake()
    {
        base.BaseAwake();

        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        _playerSpawner = ServiceLocator.Instance.Get<PlayerSpawner>();

        _enemies = new List<Enemy>();
        _playerSpawner.PlayerSpawned += OnPlayerSpawned;
    }

    public override void BaseStart()
    {
        base.BaseStart();

        var levelGenerator = ServiceLocator.Instance.Get<LevelGenerator>();
        levelGenerator.BuildNavMesh();

        foreach(var spawnPoint in _spawnPoints)
        {
            var enemy = Instantiate(spawnPoint.Prefab, spawnPoint.transform.position, Quaternion.identity);
            _enemies.Add(enemy);

            enemy.SetTarget(_target);
        }
    }

    private void OnPlayerSpawned(GameObject player)
    {
        if(player.TryGetComponent(out Player playerComponent))
        {
            _target = playerComponent;

            foreach(var enemy in _enemies)
            {
                enemy.SetTarget(_target);
            }
        }
    }
}
