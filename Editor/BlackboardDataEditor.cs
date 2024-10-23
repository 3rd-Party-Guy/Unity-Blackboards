using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Blackboard.Editor
{
    [CustomEditor(typeof(BlackboardData))]
    public class BlackboardDataEditor : UnityEditor.Editor
    {
        ReorderableList entryList;

        private void OnEnable()
        {
            entryList = new(serializedObject, serializedObject.FindProperty("entries"), true, true, true, true)
            {
                drawHeaderCallback = rect =>
                {
                    var infoSectionWidth = rect.width * .3f;

                    EditorGUI.LabelField(new(rect.x, rect.y, infoSectionWidth, EditorGUIUtility.singleLineHeight), "Key");
                    EditorGUI.LabelField(new(rect.x + infoSectionWidth + 15, rect.y, infoSectionWidth, EditorGUIUtility.singleLineHeight), "Type");
                },
                drawElementCallback = (rect, index, isActive, isFocused) =>
                {
                    var element = entryList.serializedProperty.GetArrayElementAtIndex(index);
                    rect.y += 2;

                    var keyName = element.FindPropertyRelative("keyName");
                    var type = element.FindPropertyRelative("type");
                    var value = element.FindPropertyRelative("value");

                    var infoSectionWidth = rect.width * .3f;
                    var keyNameRect = new Rect(rect.x, rect.y, infoSectionWidth, EditorGUIUtility.singleLineHeight);
                    var valueTypeRect = new Rect(rect.x + infoSectionWidth + 5, rect.y, infoSectionWidth, EditorGUIUtility.singleLineHeight);
                    var valueRect = new Rect(rect.x + infoSectionWidth * 2 + 10, rect.y, rect.width * .37f, EditorGUIUtility.singleLineHeight);

                    EditorGUI.PropertyField(keyNameRect, keyName, GUIContent.none);
                    EditorGUI.PropertyField(valueTypeRect, type, GUIContent.none);

                    switch ((AnyValue.Type) type.enumValueIndex)
                    {
                        case AnyValue.Type.Bool:
                            var boolValue = value.FindPropertyRelative("boolValue");
                            EditorGUI.PropertyField(valueRect, boolValue, GUIContent.none);
                            break;
                        case AnyValue.Type.Float:
                            var floatValue = value.FindPropertyRelative("floatValue");
                            EditorGUI.PropertyField(valueRect, floatValue, GUIContent.none);
                            break;
                        case AnyValue.Type.Int:
                            var intValue = value.FindPropertyRelative("intValue");
                            EditorGUI.PropertyField(valueRect, intValue, GUIContent.none);
                            break;
                        case AnyValue.Type.String:
                            var stringValue = value.FindPropertyRelative("stringValue");
                            EditorGUI.PropertyField(valueRect, stringValue, GUIContent.none);
                            break;
                        case AnyValue.Type.Vector3:
                            var vector3Value = value.FindPropertyRelative("vector3Value");
                            EditorGUI.PropertyField(valueRect, vector3Value, GUIContent.none);
                            break;
                        default:
                            throw new System.ArgumentOutOfRangeException();
                    }
                }
            };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            entryList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
