using System;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPartyGuy.Collections
{
    [System.Serializable]
    public class BlackboardEntryData : ISerializationCallbackReceiver
    {
        public string keyName;
        public AnyValue.Type type;
        public AnyValue value;

        public void SetValueOnBlackboard(Blackboard blackboard)
        {
            var key = blackboard.GetOrRegisterKey(keyName);
            setValueDispatchTable[value.type](blackboard, key, value);
        }

        readonly Dictionary<AnyValue.Type, Action<Blackboard, Key, AnyValue>> setValueDispatchTable = new()
        {
            { AnyValue.Type.Bool, (blackboard, key, value) => blackboard.Set<bool>(key, value) },
            { AnyValue.Type.Int, (blackboard, key, value) => blackboard.Set<int>(key, value) },
            { AnyValue.Type.Float, (blackboard, key, value) => blackboard.Set<float>(key, value) },
            { AnyValue.Type.String, (blackboard, key, value) => blackboard.Set<int>(key, value) },
            { AnyValue.Type.Vector3, (blackboard, key, value) => blackboard.Set<Vector3>(key, value) },
            { AnyValue.Type.Rigidbody, (blackboard, key, value) => blackboard.Set<Rigidbody>(key, value) },
            { AnyValue.Type.GameObject, (blackboard, key, value) => blackboard.Set<GameObject>(key, value) },
        };

        public void OnBeforeSerialize() { }
        public void OnAfterDeserialize()
        {
            value.type = type;
        }
    }
}
