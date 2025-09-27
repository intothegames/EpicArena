namespace TimeToBeEpic.Game.Services
{
    public static class EventManager
    {
        private static Dictionary<Enum, Delegate> _eventDictionary = new();

        public static void Add(Enum eventName, Delegate eventHandler)
        {
            if (!_eventDictionary.ContainsKey(eventName))
            {
                _eventDictionary[eventName] = eventHandler;
            }
            else
            {
                _eventDictionary[eventName] = Delegate.Combine(_eventDictionary[eventName], eventHandler);
            }
        }

        public static void Remove(Enum eventName, Delegate eventHandler)
        {
            if (_eventDictionary.ContainsKey(eventName))
            {
                var currentDelegate = _eventDictionary[eventName];
                currentDelegate = Delegate.Remove(currentDelegate, eventHandler);

                if (currentDelegate == null)
                {
                    _eventDictionary.Remove(eventName);
                }
                else
                {
                    _eventDictionary[eventName] = currentDelegate;
                }
            }
        }

        public static void Call(Enum eventName, params object[] args)
        {
            if (_eventDictionary.ContainsKey(eventName))
            {
                _eventDictionary[eventName].DynamicInvoke(args);
            }
        }

        public static void Clear()
        {
            _eventDictionary.Clear();
        }
    }

    public class Event
    {
        public void Call(Enum eventName, params object[] args)
        {
            EventManager.Call(eventName, args);
        }
    }

    public class EventListener
    {
        private readonly Dictionary<Enum, List<Delegate>> _mapListeners = new();

        ~EventListener()
        {
            RemoveAllListeners();
        }

        public void Add(Enum eventName, Delegate eventHandler)
        {
            EventManager.Add(eventName, eventHandler);

            if (!_mapListeners.ContainsKey(eventName))
            {
                _mapListeners[eventName] = new List<Delegate>();
            }

            List<Delegate> callbacks = _mapListeners[eventName];

            if (!callbacks.Contains(eventHandler))
            {
                callbacks.Add(eventHandler);
            }
        }

        public void Remove(Enum eventName, Delegate eventHandler)
        {
            if (_mapListeners.TryGetValue(eventName, out List<Delegate> callbacks))
            {
                if (callbacks.Contains(eventHandler))
                {
                    callbacks.Remove(eventHandler);
                    if (callbacks.Count == 0)
                    {
                        _mapListeners.Remove(eventName);
                    }
                }
            }
        }

        public void RemoveAllListeners()
        {
            foreach (var mapListener in _mapListeners)
            {
                foreach (var @delegate in mapListener.Value)
                {
                    EventManager.Remove(mapListener.Key, @delegate);
                }
            }

            _mapListeners.Clear();
        }
    }
}
