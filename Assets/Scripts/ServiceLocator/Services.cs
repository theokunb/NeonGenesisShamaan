using UnityEngine;

public class Services : BaseMonoBeh
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private CameraFollow _cameraFollow;
    [SerializeField] private LoseView _loseView;
    [SerializeField] private WeaponService _weaponService;
    [SerializeField] private GameView _gameView;
    [SerializeField] private PauseView _pauseView;

    public override void BaseAwake()
    {
        base.BaseAwake();

        ServiceLocator.Instance.Register(_enemySpawner);
        ServiceLocator.Instance.Register(_playerSpawner);
        ServiceLocator.Instance.Register(_levelGenerator);
        ServiceLocator.Instance.Register(_cameraFollow);
        ServiceLocator.Instance.Register(_loseView);
        ServiceLocator.Instance.Register(_weaponService);
        ServiceLocator.Instance.Register(_gameView);
        ServiceLocator.Instance.Register(_pauseView);
    }
}
