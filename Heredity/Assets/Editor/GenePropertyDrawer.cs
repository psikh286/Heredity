using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomPropertyDrawer(typeof(Gene<>))]
    public class GenePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            // Get the serialized properties for the Gene class fields
            var domProperty = property.FindPropertyRelative("Dom");
            var relationProperty = property.FindPropertyRelative("Relation");

            // Draw the Relation object field
            var relationRect = new Rect(position.x, position.y, position.width * 0.8f, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(relationRect, relationProperty, new GUIContent(label));

            // Draw the popup for the Dominant value
            var domRect = new Rect(position.x + position.width * 0.8f, position.y, position.width * 0.2f, EditorGUIUtility.singleLineHeight);
            domProperty.enumValueIndex = EditorGUI.Popup(domRect, "", domProperty.intValue, domProperty.enumNames);

            EditorGUI.EndProperty();
        }
    }
}
