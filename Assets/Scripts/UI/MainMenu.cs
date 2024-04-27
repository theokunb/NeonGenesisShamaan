using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private const string IsCinematicWatched = "watched";

    [SerializeField] private MenuView _menuView;
    [SerializeField] private Cinematic1View _chematic1View;
    [SerializeField] private Cinematic2View _chematic2View;

    private void Awake()
    {
        var cinematicWatched = PlayerPrefs.GetInt(IsCinematicWatched, 0);

        if (cinematicWatched == 0)
        {
            _chematic1View.Show();

            _chematic1View.Ended += OnCinematic1Ended;
        }
        else
        {
            _menuView.Show();
        }
    }

    private void OnCinematic1Ended()
    {
        _chematic1View.Hide();
        _chematic1View.Ended -= OnCinematic1Ended;

        _chematic2View.Show();
        _chematic2View.Ended += OnCinematic2Ended;
    }

    private void OnCinematic2Ended()
    {
        _chematic2View.Hide();
        _chematic2View.Ended -= OnCinematic2Ended;

        PlayerPrefs.SetInt(IsCinematicWatched, 1);

        _menuView.Show();
    }
}
