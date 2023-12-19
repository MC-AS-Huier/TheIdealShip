using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using NextShip.Api.Interfaces;

namespace NextShip.Manager;

public class EventManager : IEventManager
{
    public static EventManager _eventManager = Main._Service.Get<EventManager>();

    private readonly HashSet<IEventListener> EventListeners = [];

    private readonly List<INextEvent> RegisterEvents = [];

    public void RegisterEvent(INextEvent @event)
    {
        @event.OnRegister(this);
        RegisterEvents.Add(@event);
    }

    public void UnRegisterEvent(INextEvent @event)
    {
        @event.OnUnRegister(this);
        RegisterEvents.Remove(@event);
    }

    public void RegisterListener(IEventListener listener)
    {
        EventListeners.Add(listener);
    }

    public void UnRegisterListener(IEventListener listener)
    {
        EventListeners.Remove(listener);
    }

    public void CallEvent(INextEvent @event)
    {
        foreach (var _event in RegisterEvents.FindAll(n => n.EventName == @event.EventName))
            @event.Call(_event);
    }

    public void CallListener(string name)
    {
        EventListeners.Do(n => n.On(name));
    }

    public void CallListener(INextEvent @event)
    {
        EventListeners.Do(n => n.On(@event));
    }

    public bool TryGetEvent(string eventName, out INextEvent @event)
    {
        if (RegisterEvents.Any(n => n.EventName == eventName))
        {
            @event = RegisterEvents.FirstOrDefault(n => n.EventName == eventName);
            return true;
        }

        @event = null;
        return false;
    }

    public T GetEvent<T>() where T : INextEvent
    {
        return (T)RegisterEvents.FirstOrDefault(n => n is T);
    }

    public INextEvent GetEvent(Type type)
    {
        return RegisterEvents.FirstOrDefault(n => n.GetType() == type);
    }
}