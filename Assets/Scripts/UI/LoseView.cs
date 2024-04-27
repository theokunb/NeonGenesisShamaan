using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseView : BaseView, IService
{
    [SerializeField] private float _backgroundAlpha;
    [SerializeField] private float _fadeTime;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponentInChildren<CanvasGroup>();
    }

    public override void Hide()
    {
        gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        _canvasGroup.alpha = 0;
        Time.timeScale = 0;

        _canvasGroup.DOFade(_backgroundAlpha, _fadeTime).SetUpdate(true);
    }

    public void OnReplay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void OnExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
