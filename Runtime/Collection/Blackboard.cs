using System;
using System.Collections.Generic;

namespace Blackboard
{
    [System.Serializable]
    public class Blackboard
    {
        Dictionary<string, Key> keys = new();
        Dictionary<Key, object> entries = new();

        public List<Action> Actions { get; } = new();

        public void AddAction(Action action)
        {
            if (action == null)
            {
                throw new System.ArgumentNullException(nameof(action));
            }

            Actions.Add(action);
        }

        public void ClearActions()
        {
            Actions.Clear();
        }

        public bool TryGet<T>(Key key, out T value)
        {
            if (entries.TryGetValue(key, out var entry) && entry is Entry<T> castEntry)
            {
                value = castEntry.Value;
                return true;
            }

            value = default;
            return false;
        }

        public void Set<T>(Key key, T value)
        {
            entries[key] = new Entry<T>(key, value);
        }

        public Key GetOrRegisterKey(string keyName)
        {
            if (string.IsNullOrEmpty(keyName))
            {
                throw new System.ArgumentNullException(nameof(keyName));
            }

            if (!keys.TryGetValue(keyName, out var key))
            {
                key = new(keyName);
                keys[keyName] = key;
            }

            return key;
        }

        public bool ContainsKey(Key key)
        {
            return entries.ContainsKey(key);
        }

        public void Remove(Key key)
        {
            entries.Remove(key); 
        }
    }
}
