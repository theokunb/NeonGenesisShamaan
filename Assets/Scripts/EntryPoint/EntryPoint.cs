using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private List<BaseMonoBeh> _points;

    private void Awake()
    {
        _points.OrderBy(element => element.Priority);

        foreach(var point in _points)
        {
            point.BaseAwake();
        }
    }

    private void OnEnable()
    {
        _points.OrderBy(element => element.Priority);

        foreach (var point in _points)
        {
            point.BaseOnEnable();
        }
    }

    private void OnDisable()
    {
        _points.OrderBy(element => element.Priority);

        foreach (var point in _points)
        {
            point.BaseOnDisable();
        }
    }

    private void Start()
    {
        _points.OrderBy(element => element.Priority);

        foreach (var point in _points)
        {
            point.BaseStart();
        }
    }
}
