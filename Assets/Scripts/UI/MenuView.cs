using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuView : BaseView
{

    [SerializeField] private float _alpha;
    [SerializeField] private float _fadeDelay;
    [SerializeField] private CanvasGroup _canvasGroup;

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        _canvasGroup.alpha = 1;

        _canvasGroup.DOFade(_alpha, _fadeDelay);
    }

    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
