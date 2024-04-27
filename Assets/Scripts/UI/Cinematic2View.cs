using System;

public class Cinematic2View : BaseView
{
    public event Action Ended;

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }

    public void OnEnd()
    {
        Ended?.Invoke();
    }
}
