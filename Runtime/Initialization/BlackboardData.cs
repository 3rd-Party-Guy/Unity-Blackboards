using System.Collections.Generic;
using UnityEngine;

namespace ThirdPartyGuy.Collections
{
    [CreateAssetMenu(fileName = "ThirdPartyGuy.Collections Data", menuName = "3rd-Party-Guy/Collections/Blackboard/Data")]
    public class BlackboardData : ScriptableObject
    {
        public List<BlackboardEntryData> entries = new();

        public void SetValuesOnBlackboard(Blackboard blackboard)
        {
            foreach (var entry in entries)
            {
                entry.SetValueOnBlackboard(blackboard);
            }
        }
    }
}
