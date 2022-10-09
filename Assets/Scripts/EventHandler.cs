using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void EventCallback(int _value);

public static class EventHandler
{
    private static Dictionary<EventType, List<EventCallback>> events = new Dictionary<EventType, List<EventCallback>>();

    public static void Subscribe(EventType _eventType, EventCallback _function)
    {
        if (!events.ContainsKey(_eventType))
        {
            events[_eventType] = new List<EventCallback>();
        }
        events[_eventType].Add(_function);
    }

    public static void Unsubscribe(EventType _eventType, EventCallback _function)
    {
        if (events.ContainsKey(_eventType))
        {
            events[_eventType].Remove(_function);
        }
    }

    public static void RaiseEvent(EventType _eventType, int _value)
    {
        if (events.ContainsKey(_eventType))
        {
            foreach (EventCallback callback in events[_eventType])
            {
                callback.Invoke(_value);
            }
        }
    }
}

public enum EventType
{
    COINS_CHANGED,
    SHOP_CHANGED,
}