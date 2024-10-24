namespace ThirdPartyGuy.Collections
{
    public class PersistentProperty<T> : Property<T>
    {
        public PersistentProperty(Blackboard blackboad, string ID)
            : base(blackboad, ID) { }

        public PersistentProperty(Blackboard blackboard, string ID, T initialValue)
            : this(blackboard, ID)
        {
            context.Set(key, initialValue);
        }
    }
}
