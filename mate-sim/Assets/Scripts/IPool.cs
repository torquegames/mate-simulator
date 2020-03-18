using UnityEngine;

public interface IPool<TPrefabType> where TPrefabType : Component, IPooleable
{
    TPrefabType Get();
    void Destroy(TPrefabType prefab);
}