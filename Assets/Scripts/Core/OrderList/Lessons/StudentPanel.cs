using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Journal_Model;
using Journal_Model.Lesson;
using Journal_Model.LessonThemes;
using UnityEngine;
using UnityEngine.UI;

public class StudentPanel : MonoBehaviour
{
    public RectTransform Rect;
    [SerializeField] private Text Name;
    [SerializeField] private Toggle Presence;
    [SerializeField] private InputField[] InputFields;
    [SerializeField] private Text Total;
    private StudentSO Student;
    private LessonData LessonData;
    private LessonTheme LessonTheme;
    private int PointDataIndex;

    public void Init(StudentSO student, LessonData lessonData, LessonTheme lessonTheme, int pointDataIndex = 0)
    {
        Student = student;
        LessonData = lessonData;
        LessonTheme = lessonTheme;
        PointDataIndex = pointDataIndex;
        Name.text = Student.ToShortNSP();
    }

    public void UpdateData()
    {
        Presence.isOn = LessonData.IsPresence;
        for (int i = 0; i < InputFields.Length; i++)
        {
            if (LessonTheme.PointDatas.Count > i + PointDataIndex &&
                LessonData.Points.ContainsKey(LessonTheme.PointDatas[i]))
            {
                InputFields[i].text = LessonData.Points[LessonTheme.PointDatas[i + PointDataIndex]].ToString();
            }
            else
            {
                InputFields[i].text = "";
            }
        }

        Total.text = LessonData.Points.Values.Sum().ToString();
    }

    public void OnPresenceChanged(bool value)
    {
        LessonData.IsPresence = value;
    }

    public void OnPointChanged(int index)
    {
        if (string.IsNullOrEmpty(InputFields[index].text))
        {
            if (LessonData.Points.ContainsKey(LessonTheme.PointDatas[index + PointDataIndex]))
            {
                LessonData.Points.Remove(LessonTheme.PointDatas[index + PointDataIndex]);
            }
            return;
        }
        
        float points;
        if (float.TryParse(InputFields[index].text, out points))
        {
            if (LessonData.Points.ContainsKey(LessonTheme.PointDatas[index + PointDataIndex]))
            {
                if (Math.Abs(LessonData.Points[LessonTheme.PointDatas[index + PointDataIndex]] - points) > 0.01f)
                {
                    LessonData.Points[LessonTheme.PointDatas[index + PointDataIndex]] = points;
                    UpdateData();
                }
            }
            else
            {
                LessonData.Points.Add(LessonTheme.PointDatas[index + PointDataIndex], points);
                UpdateData();
            }
        }
        else
        {           
            if (LessonData.Points.ContainsKey(LessonTheme.PointDatas[index + PointDataIndex]))
            {
                LessonData.Points.Remove(LessonTheme.PointDatas[index + PointDataIndex]);
            }
            return;
            
        }
    }
}
