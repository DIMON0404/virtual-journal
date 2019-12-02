using System.Collections;
using System.Collections.Generic;
using Journal_Model;
using Journal_Model.Core;
using Journal_Model.Lesson;
using UI_Controllers;
using UnityEngine;
using UnityEngine.UI;

public class TotalPanel : MonoBehaviour
{
    [SerializeField] private JournalModelProxy Proxy;
    [SerializeField] private RectTransform Content;
    [SerializeField] private StudentTotalPanel Prefab;
    private List<StudentTotalPanel> Students;

    public void OnEnable()
    {
        if (Students != null)
        {
            foreach (StudentTotalPanel panel in Students)
            {
                Destroy(panel.gameObject);
            }
        }

        float totalHeight = 0;
        Students = new List<StudentTotalPanel>();
        foreach (StudentSO student in Proxy.Students)
        {
            float lessonsPoints = 0;
            foreach (Lesson lesson in Proxy.JournalModel.Lessons)
            {
                LessonData lessonData = lesson.Datas[student];
                foreach (PointData data in lessonData.Points.Keys)
                {
                    lessonsPoints += lessonData.Points[data];
                }
            }

            float extraPoints = 0;
            if (Proxy.JournalModel.ExtraPointsData.Points.ContainsKey(student))
            {
                Dictionary<PointData, float> extra = Proxy.JournalModel.ExtraPointsData.Points[student];
                foreach (PointData data in extra.Keys)
                {
                    extraPoints += extra[data];
                }
            }

            float modulePoints = 0;
            if (Proxy.JournalModel.ModulePointsData.Points.ContainsKey(student))
            {
                Dictionary<PointData, float> module = Proxy.JournalModel.ModulePointsData.Points[student];
                foreach (PointData data in module.Keys)
                {
                    modulePoints += module[data];
                }
            }

            StudentTotalPanel panel = Instantiate(Prefab, Content);
            panel.Init(student.ToShortNSP(), 
                lessonsPoints.ToString(), 
                extraPoints.ToString(),
                modulePoints.ToString(), 
                (lessonsPoints + extraPoints + modulePoints).ToString());

            Vector2 position = panel.Rect.anchoredPosition;
            position.y = -totalHeight;
            panel.Rect.anchoredPosition = position;
            totalHeight += panel.Rect.sizeDelta.y;
            Students.Add(panel);
        }

        Vector2 size = Content.sizeDelta;
        size.y = totalHeight;
        Content.sizeDelta = size;
    }
}
