using DG.Tweening;
using DG.Tweening.Plugins.Options;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Cinematic1View : BaseView
{
    [SerializeField] private Image _scene1;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Animator _animator;

    private Scene1AnimationHandler _handler;

    public event Action Ended;

    private void Awake()
    {
        _handler = GetComponentInChildren<Scene1AnimationHandler>();
    }

    public override void Hide()
    {
        _handler.Handle -= OnHandle;
        _canvasGroup.DOFade(0, 2).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public override void Show()
    {
        gameObject.SetActive(true);

        _handler.Handle += OnHandle;
    }

    private void OnHandle()
    {
        Ended?.Invoke();
    }

    private void Start()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.DOFade(0.3f, 5)
            .OnComplete(() =>
            {
                _canvasGroup.DOFade(1, 2)
                .OnComplete(() =>
                {
                    _animator.Play("Scene1");
                });
            });
    }
}
