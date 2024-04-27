using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private List<T> _objects;
    private int _size;
    private T _prefab;

    public ObjectPool(T prefab, int size)
    {
        _objects = new List<T>();
        _size = size;
        _prefab = prefab;

        CreatePool();
    }

    private void CreatePool()
    {
        for(int i = 0; i < _size; i++)
        {
            var obj = Object.Instantiate(_prefab);
            obj.gameObject.SetActive(false);
        }
    }

    public T Get()
    {
        var available = _objects.Where(element => element.gameObject.activeSelf == false).FirstOrDefault();

        if(available == null)
        {
            return null;
        }

        available.gameObject.SetActive(true);
        return available;
    }
}
