using System.Linq;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ValidateField))]
public class ValidateFieldPropertyDrawer : PropertyDrawer
{
    private ValidateField ValidationAttribute
    {
        get
        {
            return attribute as ValidateField;
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (!ValidateValue(property))
        {
            ModifyValue(property);
        }

        EditorGUI.PropertyField(position, property, label);
    }

    private bool ValidateValue(SerializedProperty property)
    {
        return property.objectReferenceValue == null || IsTypeAssignable(property.objectReferenceValue);
    }

    private void ModifyValue(SerializedProperty property)
    {
        if (property.objectReferenceValue is GameObject)
        {
            foreach (MonoBehaviour behaviour in (property.objectReferenceValue as GameObject)
                .GetComponents<MonoBehaviour>())
            {
                if (IsTypeAssignable(behaviour))
                {
                    SetValue(property, behaviour);
                    return;
                }
            }
        }

        ResetValue(property);
    }

    private bool IsTypeAssignable(Object value)
    {
        return ValidationAttribute.Type.IsInstanceOfType(value);
    }

    private void ResetValue(SerializedProperty property)
    {
        SetValue(property, null);
        Debug.LogError("Uncorrect component type in field :" + property.displayName);
    }

    private void SetValue(SerializedProperty property, Object value)
    {
        property.objectReferenceValue = value;
        property.serializedObject.ApplyModifiedProperties();
    }
}