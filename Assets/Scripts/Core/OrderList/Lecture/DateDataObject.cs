using System;
using Core.OrderList.Lesson;
using Journal_Model;
using UnityEngine;
using UnityEngine.UI;

namespace Core.OrderList
{
    public class DateDataObject : MonoBehaviour
    {
        [HideInInspector]
        public DateData Data;
        public RectTransform Rect;
        private LectureItemObject LectureItemObject;
        [SerializeField] private Text DateTimeField;
        [SerializeField] private Button SelectDate;
        [SerializeField] private Button SelectDateAfterClear;
        [SerializeField] private Button ClearDate;
        [SerializeField] private InputField Hours;
        
        public void Init(DateData data, LectureItemObject lectureItemObject)
        {
            Data = data;
            LectureItemObject = lectureItemObject;
        }
        
        public void SetDateTime(DateTime date)
        {
            DateTimeField.text = date.ToShortDateString();
            ClearDate.gameObject.SetActive(true);
            SelectDate.gameObject.SetActive(true);
            SelectDateAfterClear.gameObject.SetActive(false);
            Data.DateTime = date;
            Data.HasDate = true;
        }

        public void SetData(int hours)
        {
            ResetDate();
            Hours.text = hours.ToString();
        }

        public void SetData(DateTime date, int hours)
        {
            SetDateTime(date);
            Hours.text = hours.ToString();
        }

        public void ResetDate()
        {
            ClearDate.gameObject.SetActive(false);
            SelectDate.gameObject.SetActive(false);
            SelectDateAfterClear.gameObject.SetActive(true);
            Data.HasDate = false;
        }

        public void SetHours(string hours)
        {
            int parsedHours;
            if (int.TryParse(hours, out parsedHours))
            {
                if (parsedHours >= 0)
                {
                    Data.Hours = parsedHours;
                }
                else
                {
                    Hours.text = "0";
                }
            }
        }
        
        
        public void OnRemoveThis()
        {
            LectureItemObject.OnRemoveObject(this);
        }
    }
}