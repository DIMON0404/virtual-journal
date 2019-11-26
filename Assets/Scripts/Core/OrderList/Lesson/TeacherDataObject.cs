using System;
using System.Collections.Generic;
using Journal_Model.LessonThemes;
using UnityEngine;
using UnityEngine.UI;

namespace Core.OrderList.Lesson
{
    public class TeacherDataObject : MonoBehaviour
    {
        public RectTransform Rect;
        [SerializeField] private Dropdown Teachers;
        [SerializeField] private Text Date;

        public TeacherData TeacherData;
        private LessonItemObject LessonItemObject;
        private bool IsTeacherSelected = false;
        private List<Teacher> TeacherList;

        public void Init(TeacherData teacherData, LessonItemObject lessonItemObject, List<Teacher> teachers)
        {
            List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
            TeacherList = teachers;
            options.Add(new Dropdown.OptionData("Оберіть викладача"));
            foreach (Teacher teacher in teachers)
            {
                options.Add(new Dropdown.OptionData(teacher.ToString()));
            }

            Teachers.options = options;
            TeacherData = teacherData;
            LessonItemObject = lessonItemObject;
        }

        public void SetData(Teacher teacher, DateTime date)
        {
            if (teacher != null)
                OnTeacherSelect(TeacherList.IndexOf(teacher));
            
            SetDate(date);
        }

        public void SetDate(DateTime dateTime)
        {
            TeacherData.DateTime = dateTime;
            Date.text = dateTime.ToShortDateString();
        }

        public void OnTeacherSelect(int index)
        {
            if (!IsTeacherSelected)
            {
                if (index != 0)
                {
                    IsTeacherSelected = true;
                    Teachers.options.RemoveAt(0);
                    Teachers.value = index - 1;
                }
            }
            else
            {
                TeacherData.teacher = TeacherList[index];
            }
        }

        public void OnRemoveThis()
        {
            LessonItemObject.OnRemoveObject(this);
        }
    }
}