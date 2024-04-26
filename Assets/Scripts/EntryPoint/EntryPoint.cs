using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private List<CustomMonoBeh> _points;

    private void Awake()
    {
        _points.OrderBy(element => element.Priority);

        foreach(var point in _points)
        {
            point.Awake();
        }
    }

    private void OnEnable()
    {
        _points.OrderBy(element => element.Priority);

        foreach (var point in _points)
        {
            point.OnEnable();
        }
    }

    private void OnDisable()
    {
        _points.OrderBy(element => element.Priority);

        foreach (var point in _points)
        {
            point.OnDisable();
        }
    }

    private void Start()
    {
        _points.OrderBy(element => element.Priority);

        foreach (var point in _points)
        {
            point.Start();
        }
    }

    private void Update()
    {
        _points.OrderBy(element => element.Priority);

        foreach (var point in _points)
        {
            point.Update();
        }
    }
}
