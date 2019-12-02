using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Journal_Model;
using Journal_Model.Journal_Model;
using Journal_Model.Lesson;
using Journal_Model.LessonThemes;
using UI_Controllers;
using UnityEngine;
using UnityEngine.UI;

public class LessonPanel : MonoBehaviour
{
    [SerializeField] private JournalModelProxy Proxy;
    [SerializeField] private Text LessonName;
    [SerializeField] private Text PresenceText;
    [SerializeField] private Text[] Criteries;
    [SerializeField] private Text TotalText;
    [SerializeField] private Button LeftButton;
    [SerializeField] private Button RightButton;
    private int CurrentIndex;
    private List<PointData> Datas;
    [SerializeField] private StudentPanel Prefab;
    private List<StudentPanel> StudentPanels;
    private List<StudentSO> Students => Proxy.Students;
    [SerializeField] private RectTransform Content;
    private bool IsLesson;
    private AdditionalPoints AdditionalPoints;
    private LessonTheme LessonTheme;

    public void InitAdditionalData(string name, AdditionalPoints points)
    {
        IsLesson = false;
        AdditionalPoints = points;
        Init(name, points.Points, false);
    }

    public void InitLesson(LessonTheme lesson)
    {
        IsLesson = true;
        LessonTheme = lesson;
        Init(lesson.Name, lesson.PointDatas, true);
    }
    
    public void Init(string name, List<PointData> datas, bool presenceExist)
    {
        LessonName.text = name;
        Datas = datas;
        CurrentIndex = 0;
        PresenceText.gameObject.SetActive(presenceExist);
        UpdateDatas();
    }

    public void SetNextCriteries()
    {
        CurrentIndex++;
        UpdateDatas();
    }

    public void SetPreviousCriteries()
    {
        CurrentIndex--;
        UpdateDatas();
    }

    public void UpdateDatas()
    {
        for (int i = 0; i < Criteries.Length; i++)
        {
            if (Datas.Count - CurrentIndex > i)
            {
                Criteries[i].gameObject.SetActive(true);
                Criteries[i].text = Datas[i + CurrentIndex].Name;
            }
            else
            {
                Criteries[i].gameObject.SetActive(false);
            }
        }
        for (int i = 0, min = Mathf.Min(Datas.Count - CurrentIndex, Criteries.Length); i < min; i++)
        {
            Criteries[i].text = Datas[i + CurrentIndex].Name;
        }

        LeftButton.enabled = CurrentIndex > 0;
        RightButton.enabled = Datas.Count - CurrentIndex > Criteries.Length;
        if (StudentPanels != null)
        {
            foreach (StudentPanel panel in StudentPanels)
            {
                Destroy(panel.gameObject);
            }
        }
        
        StudentPanels = new List<StudentPanel>();
        float totalHeight = 0;
        foreach (StudentSO student in Students)
        {
            StudentPanel panel = Instantiate(Prefab, Content);
            if (IsLesson)
            {
                Dictionary<StudentSO, LessonData> datas = Proxy.JournalModel.Lessons
                    .First(lesson => lesson.LessonTheme == LessonTheme).Datas;
                LessonData lessonData;
                if (datas.ContainsKey(student))
                {
                    lessonData = datas[student];
                }
                else
                {
                    lessonData = new LessonData();
                    datas.Add(student, lessonData);
                }
                panel.Init(student, lessonData, LessonTheme, CurrentIndex);
            }
            else
            {
                AdditionalPointsData additionalPointsData;
                if (Proxy.JournalModel.ExtraPointsData.AdditionalPoints == AdditionalPoints)
                {
                    additionalPointsData = Proxy.JournalModel.ExtraPointsData;
                }
                else
                {
                    additionalPointsData = Proxy.JournalModel.ModulePointsData;
                }
                panel.Init(student, additionalPointsData, CurrentIndex);
            }

            Vector2 position = panel.Rect.anchoredPosition;
            position.y = -totalHeight;
            panel.Rect.anchoredPosition = position;
            totalHeight += panel.Rect.sizeDelta.y;
            StudentPanels.Add(panel);
        }

        Vector2 size = Content.sizeDelta;
        size.y = totalHeight;
        Content.sizeDelta = size;
    }
}
