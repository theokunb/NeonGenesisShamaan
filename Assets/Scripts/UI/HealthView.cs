using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : BaseView
{
    [SerializeField] float _changeSpeed;

    private Damageble _damageble;
    private Image _image;

    private Coroutine _coroutine;

    public override void Hide()
    {
    }

    public override void Show()
    {
    }

    private void Start()
    {
        var playerSpawner = ServiceLocator.Instance.Get<PlayerSpawner>();
        _image = GetComponent<Image>();

        playerSpawner.PlayerSpawned += OnPlayerSpawned;
    }

    private void OnPlayerSpawned(GameObject obj)
    {
        if (obj.TryGetComponent(out Damageble damageble))
        {
            _damageble = damageble;

            _damageble.OnCharacterTakeDamageEvent += OnTakeDamage;
        }
    }

    private void OnTakeDamage(object obj)
    {
        var value = _damageble.HitPoint / _damageble.MaxHealth;

        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeHealthBar(value));
    }

    private IEnumerator ChangeHealthBar(float targetValue)
    {
        while (true)
        {
            _image.fillAmount = Mathf.MoveTowards(_image.fillAmount, targetValue, Time.deltaTime * _changeSpeed);
            
            if(_image.fillAmount == targetValue)
            {
                break;
            }

            yield return null;
        }
    }
}
