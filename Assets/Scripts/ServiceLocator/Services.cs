using UnityEngine;

public class Services : BaseMonoBeh
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private CameraFollow _cameraFollow;

    public override void BaseAwake()
    {
        base.BaseAwake();

        ServiceLocator.Instance.Register(_enemySpawner);
        ServiceLocator.Instance.Register(_playerSpawner);
        ServiceLocator.Instance.Register(_levelGenerator);
        ServiceLocator.Instance.Register(_cameraFollow);
    }
}
