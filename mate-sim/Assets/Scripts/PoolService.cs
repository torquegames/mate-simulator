using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class PoolService : MonoBehaviour
{
    private IPool<BallWater> _pool;
    public BallWater prefab;
    public int initialCapacity = 300;
    
    private void Start()
    {
        _pool = new StackPool<BallWater>(initialCapacity,prefab);
    }

    public IPool<BallWater> GetPool()
    {
        return _pool;
    }
    
}
