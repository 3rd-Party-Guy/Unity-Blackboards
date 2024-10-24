using System;
using ThirdPartyGuy.Collections;

namespace ThirdPartyGuy.Collections
{
    public abstract class Property<T>
    {
        protected Key key;
        protected Blackboard context;
        protected string ID;

        protected Property(Blackboard blackboard, string ID)
        {
            this.ID = ID;
            context = blackboard;
            key = context.GetOrRegisterKey(ID);
        }

        public T Value
        {
            get => context.Get<T>(key);
            set => context.Set(key, value);
        }
    }
}
