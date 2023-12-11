using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IMessage
{
    bool Completed { get; }
}



public interface IBroker
{
    void AddListener<TMessage>(Action<TMessage> listener) where TMessage : IMessage;
    void RemoveListener<TMessage>(Action<TMessage> listener);
    /// <summary>
    /// Puts the message into a queue.
    /// Later invokes them one by one in the right order.
    /// </summary>
    /// <param name="message"></param>
    /// <typeparam name="TMessage"></typeparam>
    void Send<TMessage>(TMessage message);
}

public static class Broker
{
    private static Dictionary<string, Action<object>> _listeners = new();
    public static void AddListener(string messageName, Action<object> listener)
    {
        if (_listeners.TryGetValue(messageName, out var listeners))
        {
            listeners += listener;
            _listeners[messageName] = listeners;
        }
        else
        {
            _listeners[messageName] = listener;
        }
    }

    public static void SendMessage(string messageName, object message)
    {
        if (_listeners.TryGetValue(messageName, out var listeners))
        {
            listeners?.Invoke(message);
        }
    }
}
