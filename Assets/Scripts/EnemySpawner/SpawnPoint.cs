using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private BaseEnemy _prefab;

    public BaseEnemy Prefab => _prefab;
}
