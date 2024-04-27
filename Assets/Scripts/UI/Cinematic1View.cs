using DG.Tweening;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

public class Cinematic1View : BaseView
{
    [SerializeField] private Image _scene1;

    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Animator _animator;

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }
    private void Start()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.DOFade(0.2f, 5)
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
