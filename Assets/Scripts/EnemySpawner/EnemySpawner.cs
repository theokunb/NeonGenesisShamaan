using UnityEngine;

public class EnemySpawner : BaseMonoBeh, IService
{
    [SerializeField] private Enemy _prefab;

    private SpawnPoint[] _spawnPoints;

    public override void BaseAwake()
    {
        base.BaseAwake();

        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    public override void BaseStart()
    {
        base.BaseStart();

        var levelGenerator = ServiceLocator.Instance.Get<LevelGenerator>();
        levelGenerator.BuildNavMesh();

        foreach(var spawnPoint in _spawnPoints)
        {
            Instantiate(_prefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
