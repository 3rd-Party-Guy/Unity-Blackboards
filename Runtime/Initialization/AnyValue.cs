using UnityEngine;

namespace Blackboard
{
    [System.Serializable]
    public class AnyValue
    {
        public enum Type { Int, Float, Bool, String, Vector3 }
        public Type type;

        public bool boolValue;
        public float floatValue;
        public int intValue;
        public string stringValue;
        public Vector3 vector3Value;

        public static implicit operator bool(AnyValue value) => value.ConvertValue<bool>();
        public static implicit operator float(AnyValue value) => value.ConvertValue<float>();
        public static implicit operator int(AnyValue value) => value.ConvertValue<int>();
        public static implicit operator string(AnyValue value) => value.ConvertValue<string>();
        public static implicit operator Vector3(AnyValue value) => value.ConvertValue<Vector3>();

        T ConvertValue<T>()
        {
            return type switch
            {
                Type.Bool => AsBool<T>(boolValue),
                Type.Float => AsFloat<T>(floatValue),
                Type.Int => AsInt<T>(intValue),
                Type.String => (T)(object)stringValue,
                Type.Vector3 => (T)(object)vector3Value,
                _ => throw new System.NotSupportedException($"3rd-Party-Guy.Collections.Blackboard: Not supported value type: {typeof(T)}")
            };
        }

        T AsBool<T>(bool value)
        {
            return typeof(T) == typeof(bool)
                && value is T correctType ? correctType : default;
        }

        T AsInt<T>(int value)
        {
            return typeof(T) == typeof(int)
                && value is T correctType ? correctType : default;
        }

        T AsFloat<T>(float value)
        {
            return typeof(T) == typeof(float)
                && value is T correctType ? correctType : default;
        }
    }
}
