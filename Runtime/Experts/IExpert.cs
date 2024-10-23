namespace ThirdPartyGuy.Collections
{
    public interface IExpert
    {
        int GetPriority(Blackboard blackboard);
        void Execute(Blackboard blackboard);
    }
}
