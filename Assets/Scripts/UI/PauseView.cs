using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseView : BaseView, IService
{
    [SerializeField] private CanvasGroup _canvasGroup;


    public override void Hide()
    {
        Time.timeScale = 1;

        _canvasGroup.DOFade(0, 0.7f).SetUpdate(true).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;

        _canvasGroup.DOFade(0.7f, 0.7f).SetUpdate(true);
    }

    public void OnPlay()
    {
        Hide();
    }

    public void OnExit()
    {
        SceneManager.LoadScene(0);
    }
}
