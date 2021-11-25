using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PerpetualJourney.Editor
{
    [CustomPropertyDrawer(typeof(EnumNamedArrayAttribute))]
    public class NamedEnumArrayDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EnumNamedArrayAttribute enumNames = attribute as EnumNamedArrayAttribute;
            int index = System.Convert.ToInt32(property.propertyPath.Substring(property.propertyPath.IndexOf("[")).Replace("[", "").Replace("]", ""));
            if (index < enumNames.Names.Length)
            {
                label.text = enumNames.Names[index];
            }
            EditorGUI.PropertyField(position, property, label, true);
        }
    }
}
