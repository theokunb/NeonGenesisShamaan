using System;
using UnityEngine;

public class PlayerSpawner : BaseMonoBeh, IService
{
    [SerializeField] private Transform _spawnPosition;

    public GameObject player;
    public GameObject CreatedPlayer { get; private set; }

    public event Action<GameObject> PlayerSpawned;

    public override void BaseAwake()
    {
        base.BaseAwake();
    }

    public override void BaseStart()
    {
        CreatedPlayer = Instantiate(player, _spawnPosition.position, Quaternion.identity);
        PlayerSpawned?.Invoke(CreatedPlayer);

        var animationHandler = CreatedPlayer.GetComponentInChildren<AnimationHandler>();
        animationHandler.DieAnimationEndedEvent += DieAnimationEnded;
    }

    private void DieAnimationEnded()
    {
        var loseView = ServiceLocator.Instance.Get<LoseView>();
        loseView.Show();
    }
}
