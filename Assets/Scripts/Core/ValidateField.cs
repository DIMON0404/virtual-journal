using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class ValidateField : PropertyAttribute
{
    public Type Type;

    public ValidateField(Type type)
    {
        this.Type = type;
    }
}
