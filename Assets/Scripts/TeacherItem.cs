using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacherItem : Item
{
    public Text Text;

    private Teacher _itemIntstance;
    public override ItemSO ItemSO
    {
        get { return _itemIntstance; }
        set
        {
            if (value is Teacher teacher)
            {
                _itemIntstance = teacher;
                Text.text = teacher.ToString();
            }
        }
    }
}
