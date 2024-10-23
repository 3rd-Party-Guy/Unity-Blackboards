namespace Blackboard
{
    public interface IExpert
    {
        int GetPriority(Blackboard blackboard);
        void Execute(Blackboard blackboard);
    }
}
