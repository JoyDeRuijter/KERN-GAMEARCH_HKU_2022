using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : IPoolable 
{

    private List<T> activePool = new List<T>();
    private List<T> inactivePool = new List<T>();

    // private T AddNewItemToPool()
    // {
        
    // }

    // public T RequestObject()
    // {
        
    // }

    // public T ActivateItem(T item)
    // {
        
    // }

    public void ReturnObjectToPool(T item)
    {

    }

}

public interface IPoolable
{
    bool Active{ get; set;}
    void OnEnableObject();
    void OnDisableObject();
}