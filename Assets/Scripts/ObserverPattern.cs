using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void UnregisterObserver(IObserver observer);
    void NotifyObserver(object parameter);
}

public interface IObserver
{
    void UpdateObserver(ISubject subject, object parameter);
}

