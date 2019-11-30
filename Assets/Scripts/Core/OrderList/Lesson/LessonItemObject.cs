using System;
using System.Collections.Generic;
using Journal_Model.LessonThemes;
using UnityEngine;
using UnityEngine.UI;

namespace Core.OrderList.Lesson
{
    public class LessonItemObject : OrderItemObject<LessonItem>
    {
        public InputField IDField;
        public InputField NameField;
        public Action OnIdChagned;
        public LessonTheme Lesson => OrderItem.Lesson;
        public TeacherDataObject Prefab;
        public List<TeacherDataObject> TeacherDataObjects;
        public Action OnRecalculateContent;
        [SerializeField] private RectTransform AddButton;
        public List<Teacher> Teachers;


        public void SetId(int id)
        {
            Lesson.ID = id;
            IDField.text = id.ToString();
        }
        
        public void OnIdChanged(string id)
        {
            Lesson.ID = int.Parse(id);
            OnIdChagned.Invoke();
        }

        public void SetName(string name)
        {
            Lesson.Name = name;
            NameField.text = name;
        }

        public void OnNameChanged(string name)
        {
            Lesson.Name = name;
        }
        
        public void OnInit()
        {
            IDField.text = Lesson.ID.ToString();
            NameField.text = Lesson.Name;
            int totalHeight = 180;
            if (OrderItem.Lesson.TeacherDatas.Count > 0)
            {
                totalHeight -= 80;
            }
            
            foreach (TeacherData data in OrderItem.Lesson.TeacherDatas)
            {
                TeacherDataObject dataObject = Instantiate(Prefab, transform);
                dataObject.Init(data, this, Teachers);
                Vector2 position = dataObject.Rect.anchoredPosition;
                position.y = -totalHeight;
                dataObject.Rect.anchoredPosition = position;
                TeacherDataObjects.Add(dataObject);
                dataObject.SetData(data.teacher, data.HasData ? data.DateTime.DateTime : DateTime.Now);
                totalHeight += 80;
            }

            Vector2 positionButton = AddButton.anchoredPosition;
            positionButton.y = -totalHeight + 80;
            AddButton.anchoredPosition = positionButton;
            Vector2 size = Rect.sizeDelta;
            size.y = totalHeight;
            Rect.sizeDelta = size;
        }

        public void RecalculateContent()
        {
            Vector2 size = Rect.sizeDelta;
            size.y = 100 + 80 + TeacherDataObjects.Count * 80;
            Rect.sizeDelta = size;
            OnRecalculateContent.Invoke();
        }

        public void AddNewTeacherData()
        {
            TeacherDataObject dataObject = Instantiate(Prefab, transform);
            Vector2 position = dataObject.Rect.anchoredPosition;
            position.y = -(20 + TeacherDataObjects.Count * 80);
            dataObject.Rect.anchoredPosition = position;
            AddButton.anchoredPosition = position - new Vector2(0, 80);
            TeacherData teacherData = new TeacherData();
            dataObject.TeacherData = teacherData;
            OrderItem.Lesson.TeacherDatas.Add(teacherData);
            TeacherDataObjects.Add(dataObject);
            dataObject.Init(teacherData, this, Teachers);
            RecalculateContent();
        }

        public void OnRemoveObject(TeacherDataObject teacherDataObject)
        {
            Lesson.TeacherDatas.Remove(teacherDataObject.TeacherData);
            TeacherDataObjects.Remove(teacherDataObject);
            Destroy(teacherDataObject.gameObject);
            RecalculateContent();
        }
    }
}