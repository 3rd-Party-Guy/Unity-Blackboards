using System.Collections.Generic;
using UnityEngine;

namespace ThirdPartyGuy.Collections
{
    [CreateAssetMenu(fileName = "ThirdPartyGuy.Collections Data", menuName = "3rd-Party-Guy/Collections/Blackboard/Data")]
    public class BlackboardData : ScriptableObject
    {
        [SerializeField] List<BlackboardData> subTemplates = new();
        [SerializeField] List<BlackboardEntryData> entries = new();

        public void SetValuesOnBlackboard(Blackboard blackboard)
        {
            foreach (var template in subTemplates)
            {
                if (template == this)
                {
                    Debug.LogWarning("3rd-Party-Guy.Collections: You cannot assing a template to itself");
                    continue;
                }

                template.SetValuesOnBlackboard(blackboard);
            }

            foreach (var entry in entries)
            {
                entry.SetValueOnBlackboard(blackboard);
            }
        }
    }
}
