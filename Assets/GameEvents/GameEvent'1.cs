using System.Collections.Generic;
using UnityEngine;

public class GameEvent<T> : ScriptableObject
{
    private List<GameEventListener<T>> listeners = new List<GameEventListener<T>>();

    public void AddListener(GameEventListener<T> newListener)
    {
        listeners.Add(newListener);
    }

    public void RemoveListener(GameEventListener<T> listenerToRemove)
    {
        listeners.Remove(listenerToRemove);
    }

    public void Raise(T value)
    {
        foreach (var eventListener in listeners)
        {
            eventListener.OnEventRaised(value);
        }
    }
}
