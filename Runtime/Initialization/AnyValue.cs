using UnityEngine;

namespace ThirdPartyGuy.Collections
{
    [System.Serializable]
    public class AnyValue
    {
        public enum Type { Int, Float, Bool, String, Vector3, Rigidbody, GameObject }
        public Type type;

        public bool boolValue;
        public float floatValue;
        public int intValue;
        public string stringValue;
        public Vector3 vector3Value;
        public Rigidbody rigidbodyValue;
        public GameObject gameobjectValue;

        public static implicit operator bool(AnyValue value) => value.ConvertValue<bool>();
        public static implicit operator float(AnyValue value) => value.ConvertValue<float>();
        public static implicit operator int(AnyValue value) => value.ConvertValue<int>();
        public static implicit operator string(AnyValue value) => value.ConvertValue<string>();
        public static implicit operator Vector3(AnyValue value) => value.ConvertValue<Vector3>();
        public static implicit operator Rigidbody(AnyValue value) => value.ConvertValue<Rigidbody>();
        public static implicit operator GameObject(AnyValue value) => value.ConvertValue<GameObject>();

        T ConvertValue<T>()
        {
            return type switch
            {
                Type.Bool => AsType<T, bool>(boolValue),
                Type.Float => AsType<T, float>(floatValue),
                Type.Int => AsType<T, int>(intValue),
                Type.String => (T)(object)stringValue,
                Type.Vector3 => (T)(object)vector3Value,
                Type.Rigidbody => (T)(object)rigidbodyValue,
                Type.GameObject => (T)(object)gameobjectValue,
                _ => throw new System.NotSupportedException($"3rd-Party-Guy.Collections.Blackboard: Not supported value type: {typeof(T)}")
            };
        }

        T AsType<T, TValue>(TValue value)
        {
            return typeof(T) == typeof(TValue)
                && value is T correctType ? correctType : default;
        }
    }
}
