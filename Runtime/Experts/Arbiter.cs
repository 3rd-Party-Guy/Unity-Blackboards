using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirdPartyGuy.Collections
{
    public class Arbiter
    {
        readonly List<IExpert> experts = new();

        public void RegisterExpert(IExpert expert)
        {
            if (expert == null)
            {
                throw new System.ArgumentNullException(nameof(expert));
            }

            experts.Add(expert);
        }

        public List<Action> Iteration(Blackboard blackboard)
        {
            IExpert bestExpert = experts.Aggregate((best, next) => next.GetPriority(blackboard) > best.GetPriority(blackboard) ? next : best);

            bestExpert?.Execute(blackboard);
            var actions = blackboard.Actions;

            blackboard.ClearActions();
            return actions;
        }
    }
}
