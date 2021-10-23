using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject
{
    private List<T> items = new List<T>();

    public void Clear()
    {
        items.Clear();
    }

    public void Add(T t)
    {
        if (!items.Contains(t))
        {
            items.Add(t);
        }
    }

    public void Remove(T t)
    {
        if (items.Contains(t))
        {
            items.Remove(t);
        }
    }

    public T GetItem(int index)
    {
        return items[index];
    }
}
