using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private bool _isActive = false;

    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;

            SetEnemyActivity(IsActive);
        }
    }

    private List<Enemy> _enemyList = new List<Enemy>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            IsActive = true;

            var cameraFollow = ServiceLocator.Instance.Get<CameraFollow>();
            cameraFollow.LookAt(this);
        }

        if (collision.TryGetComponent(out Enemy enemy))
        {
            _enemyList.Add(enemy);

            SetEnemyActivity(IsActive);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            IsActive = false;
        }
    }

    private void SetEnemyActivity(bool status)
    {
        foreach (Enemy enemy in _enemyList)
        {
            if(enemy.HasDestroyed == false)
            {
                enemy.enabled = status;
            }
        }
    }
}
