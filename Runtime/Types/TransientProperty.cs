using System;

namespace ThirdPartyGuy.Collections
{
    public class TransientProperty<T> : Property<T>
    {
        public TransientProperty(Blackboard blackboard, T initialValue = default)
            : base(blackboard, Guid.NewGuid().ToString())
        {
            context.Set(key, initialValue);
        }
    }
}
