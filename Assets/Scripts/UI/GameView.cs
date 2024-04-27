using DG.Tweening;
using UnityEngine;

public class GameView : BaseView, IService
{
    private CanvasGroup _canvasGroup;
    private NewControls _newControls;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _newControls = new NewControls();
    }

    private void OnEnable()
    {
        _newControls.Enable();
        _newControls.Player.Escape.performed += OnEscapePerformed;

    }

    private void OnDisable()
    {
        _newControls?.Disable();
        _newControls.Player.Escape.performed -= OnEscapePerformed;
    }

    public override void Hide()
    {
    }

    public override void Show()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.DOFade(1, 2);
    }

    private void OnEscapePerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        var pauseView = ServiceLocator.Instance.Get<PauseView>();

        if(pauseView.gameObject.activeSelf)
        {
            pauseView.Hide();
        }
        else
        {
            pauseView.Show();
        }
    }
}
