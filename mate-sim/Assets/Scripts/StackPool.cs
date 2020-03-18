using System;

using System.Collections.Generic;

using System.Linq;

using UnityEngine;

using Object = UnityEngine.Object;


public class StackPool<TPrefabType> : IPool<TPrefabType> where TPrefabType : Component , IPooleable
{
    private Guid _guid;
    private Stack<TPrefabType> _pool;
    private int _capacity;
    private TPrefabType _prefab;
    
    public StackPool(int capacity, TPrefabType prefab)
    {
        _guid = Guid.NewGuid();
        _prefab = prefab;
        _capacity = Mathf.Max(1,capacity);
        _pool = new Stack<TPrefabType>(_capacity);
        FillPool();
    }

    private void FillPool()
    {
        for (var i = 0; i < _capacity; i++)
        {
            var element = Object.Instantiate(_prefab); //UnityEngine object
            _pool.Push(element);
            element.IsPooled = true;
            element.Guid = _guid;
        }
    }

    public TPrefabType Get()
    {
        if (!_pool.Any())
        {
            FillPool();
        }
        var element = _pool.Pop();
        element.IsPooled = false;
        return element;
    }

    public void Destroy(TPrefabType element)
    {
        if (element.Guid != _guid || element.IsPooled) return;
        element.IsPooled = true;
        _pool.Push(element);
    }


}
