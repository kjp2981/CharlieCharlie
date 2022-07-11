using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : PoolableMono
{
    private Stack<T> _pool = new Stack<T>();
    private T _prefab;
    private Transform _parent;

    public Pool(T prefab, Transform parent, int count = 10)
    {
        _prefab = prefab;
        _parent = parent;
        
        for(int i = 0; i < count; i++)
        {
            T obj = GameObject.Instantiate(prefab, parent);
            obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
            obj.gameObject.SetActive(false);
            _pool.Push(obj);
        }
    }

    public T Pop()
    {
        T obj = null;
        if(_pool.Count <= 0)
        {
            obj = GameObject.Instantiate(_prefab, _parent);
            obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
        }
        else
        {
            obj = _pool.Pop(); //스택의 맨 꼭대기에 있는 녀석을 가져다 쓴다.
            obj.gameObject.SetActive(true);
        }
        return obj;
    }

    public void Push(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Push(obj);
    }

    
}
