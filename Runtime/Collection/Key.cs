using System;

namespace Blackboard
{
    [System.Serializable]
    public readonly struct Key : IEquatable<Key>
    {
        readonly string name;
        readonly int hash;

        public Key(string name)
        {
            this.name = name;
            hash = FNV1a.Compute(name);
        }

        public bool Equals(Key other)
        {
            return hash == other.hash;
        }

        public override bool Equals(object obj)
        {
            return obj is Key other && Equals(other);
        }

        public override int GetHashCode()
        {
            return hash;
        }

        public override string ToString()
        {
            return name;
        }

        public static bool operator ==(Key left, Key right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Key left, Key right)
        {
            return !left.Equals(right);
        }
    }
}
