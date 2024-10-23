using System;

namespace Blackboard
{
    [System.Serializable]
    public class Entry<T>
    {
        public Key Key { get; }
        public T Value { get; }
        public Type ValueType { get; }

        public Entry(Key key, T value)
        {
            Key = key;
            Value = value;
            ValueType = typeof(T);
        }

        public override bool Equals(object obj)
        {
            return obj is Entry<T> other && other.Key == Key;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }
}
