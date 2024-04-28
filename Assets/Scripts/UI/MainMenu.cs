using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private const string IsCinematicWatched = "watched";

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private MenuView _menuView;
    [SerializeField] private Cinematic1View _chematic1View;
    [SerializeField] private Cinematic2View _chematic2View;
    [SerializeField] private Cinematic2View _chematic3View;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        var cinematicWatched = PlayerPrefs.GetInt(IsCinematicWatched, 0);

        if (cinematicWatched == 0)
        {
            _audioSource.Play();
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

        _chematic3View.Show();
        _chematic3View.Ended += OnChematic3View_Ended;

    }

    private void OnChematic3View_Ended()
    {
        _chematic3View.Hide();
        _chematic3View.Ended -= OnChematic3View_Ended;

        PlayerPrefs.SetInt(IsCinematicWatched, 1);

        _menuView.Show();
    }
}
