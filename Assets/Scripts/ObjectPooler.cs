using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject PooledObject;
    public int PooledAmount = 20;
    public bool WillGrow = true;

    private List<GameObject> _pooledObjects;

    private void Start()
    {
        _pooledObjects = new List<GameObject>();

        for (var i = 0; i < PooledAmount; i++)
        {
            var obj = Instantiate(PooledObject);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (var obj in _pooledObjects)
        {
            if (!obj.activeInHierarchy) return obj;
        }

        if (!WillGrow) return null;
        {
            var obj = Instantiate(PooledObject);
            _pooledObjects.Add(obj);
            return obj;
        }
    }
}