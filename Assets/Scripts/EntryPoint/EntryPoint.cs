using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private List<BaseMonoBeh> _points;

    private void Awake()
    {
        _points = _points.OrderBy(element => element.Priority).ToList();

        foreach(var point in _points)
        {
            point.BaseAwake();
        }
    }

    private void OnEnable()
    {
        foreach (var point in _points)
        {
            point.BaseOnEnable();
        }
    }

    private void OnDisable()
    {
        foreach (var point in _points)
        {
            point.BaseOnDisable();
        }
    }

    private void Start()
    {
        foreach (var point in _points)
        {
            point.BaseStart();
        }
    }
}
