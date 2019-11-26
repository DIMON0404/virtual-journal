using System;
using System.Linq;
using System.Reflection;
using UI_Controllers;
using UnityEditor;
using UnityEngine;
using Utility;

namespace Editor
{
    [CustomPropertyDrawer(typeof(DateTimeHolder))]
    public class DateTimeHolderDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            System.Object dateTimeObject =
                GetObjectByPath(property.propertyPath.Split('.'), property.serializedObject.targetObject);
            if (dateTimeObject == null)
            {
                GUI.Label(position, "null");
                return;
            }

            DateTimeHolder dateTime = (DateTimeHolder) dateTimeObject;
            GUI.Label(position, dateTime.DateTime.ToShortDateString());
        }

        private System.Object GetObjectByPath(string[] paths, System.Object target)
        {
            if (target == null)
                return null;

            if (paths.Length > 1)
            {
                string currentPath = paths[0];
                if (currentPath == "Array" && paths[1].Substring(0, 5) == "data[" &&
                    paths[1][paths[1].Length - 1] == ']')
                {
                    string[] newPaths = new string[paths.Length - 2];
                    for (int i = 2; i < paths.Length; i++)
                    {
                        newPaths[i - 2] = paths[i];
                    }

                    Array targetAsArray = target as Array;
                    if (targetAsArray != null)
                    {
                        return GetObjectByPath(newPaths,
                            targetAsArray.GetValue(int.Parse(paths[1].Substring(5, paths[1].Length - 6))));
                    }
                    else
                    {
                        FieldInfo fieldInfo = target.GetType()
                            .GetField("_items", BindingFlags.Instance | BindingFlags.NonPublic);
                        if (fieldInfo != null)
                        {
                             target = fieldInfo.GetValue(target);
                             targetAsArray = target as Array;
                             if (targetAsArray != null)
                             {
                                 return GetObjectByPath(newPaths,
                                     targetAsArray.GetValue(int.Parse(paths[1].Substring(5, paths[1].Length - 6))));
                             }
                        }

                        return null;
                    }
                }
                else
                {
                    FieldInfo fieldInfo = target.GetType().GetField(currentPath);
                    string[] newPaths = new string[paths.Length - 1];
                    for (int i = 1; i < paths.Length; i++)
                    {
                        newPaths[i - 1] = paths[i];
                    }

                    return GetObjectByPath(newPaths, fieldInfo.GetValue(target));
                }
            }
            else
            {
                return fieldInfo.GetValue(target);
            }
        }
    }
}