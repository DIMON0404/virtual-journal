using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Journal_Model;
using Journal_Model.Journal_Model;
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
    private List<PointData> Datas;
    private bool IsLesson;
    private LessonData LessonData;
    private AdditionalPointsData AdditionalPointsData;
    private Dictionary<PointData, float> Points;
    private int PointDataIndex;

    public void Init(StudentSO student, LessonData lessonData, LessonTheme lessonTheme, int pointDataIndex = 0)
    {
        Student = student;
        Datas = lessonTheme.PointDatas;
        IsLesson = true;
        LessonData = lessonData;
        Points = lessonData.Points;
        PointDataIndex = pointDataIndex;
        Name.text = Student.ToShortNSP();
        UpdateData();
    }

    public void Init(StudentSO student, AdditionalPointsData additionalPointsData, int pointDataIndex = 0)
    {
        Student = student;
        IsLesson = false;
        AdditionalPointsData = additionalPointsData;
        Datas = additionalPointsData.AdditionalPoints.Points;
        if (additionalPointsData.Points.ContainsKey(student))
            Points = additionalPointsData.Points[student];
        else
        {
            Points = new Dictionary<PointData, float>();
            additionalPointsData.Points.Add(student, Points);
        }
        PointDataIndex = pointDataIndex;
        Name.text = Student.ToShortNSP();
        UpdateData();
    }

    public void UpdateData()
    {
        if (IsLesson)
        {
            Presence.gameObject.SetActive(true);
            Presence.isOn = LessonData.IsPresence;
        }
        else
        {
            Presence.gameObject.SetActive(false);
        }

        for (int i = 0; i < InputFields.Length; i++)
        {
            if (Datas.Count > i + PointDataIndex)
            {
                InputFields[i].gameObject.SetActive(true);
                if (Points.ContainsKey(Datas[i + PointDataIndex]))
                {
                    InputFields[i].text = Points[Datas[i + PointDataIndex]].ToString();
                }
                else
                {
                    InputFields[i].text = "";
                }
            }
            else
            {
                InputFields[i].gameObject.SetActive(false);
            }
        }

        Total.text = Points.Values.Sum().ToString();
    }

    public void OnPresenceChanged(bool value)
    {
        LessonData.IsPresence = value;
    }

    public void OnPointChanged(int index)
    {
        if (string.IsNullOrEmpty(InputFields[index].text))
        {
            if (Points.ContainsKey(Datas[index + PointDataIndex]))
            {
                Points.Remove(Datas[index + PointDataIndex]);
            }
            return;
        }
        
        float points;
        if (float.TryParse(InputFields[index].text, out points))
        {
            if (Points.ContainsKey(Datas[index + PointDataIndex]))
            {
                if (Math.Abs(Points[Datas[index + PointDataIndex]] - points) > 0.01f)
                {
                    Points[Datas[index + PointDataIndex]] = points;
                    UpdateData();
                }
            }
            else
            {
                Points.Add(Datas[index + PointDataIndex], points);
                UpdateData();
            }
        }
        else
        {           
            if (Points.ContainsKey(Datas[index + PointDataIndex]))
            {
                Points.Remove(Datas[index + PointDataIndex]);
            }
            return;
            
        }
    }
}
