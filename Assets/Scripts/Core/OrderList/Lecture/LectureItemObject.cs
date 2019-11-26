using System;
using System.Collections.Generic;
using Journal_Model;
using UnityEngine;
using UnityEngine.UI;

namespace Core.OrderList
{
    public class LectureItemObject : OrderItemObject<LectureItem>
    {
        public InputField IDField;
        public InputField NameField;
        public Text DateTimeField;
        public Action OnIdChagned;
        public LectureTheme Lecture => OrderItem.Lecture;
        public DateDataObject Prefab;
        public List<DateDataObject> DataObjects;
        [SerializeField] private RectTransform AddButton;
        public Action OnRecalculateContent;


        public void SetId(int id)
        {
            Lecture.ID = id;
            IDField.text = id.ToString();
        }
        
        public void OnIdChanged(string id)
        {
            Lecture.ID = int.Parse(id);
            OnIdChagned.Invoke();
        }

        public void SetName(string name)
        {
            Lecture.Name = name;
            NameField.text = name;
        }

        public void OnNameChanged(string name)
        {
            Lecture.Name = name;
        }

        public void OnInit()
        {
            IDField.text = Lecture.ID.ToString();
            NameField.text = Lecture.Name;
            
            int totalHeight = 180;
            if (OrderItem.Lecture.Datas.Count > 0)
            {
                totalHeight -= 80;
            }
            foreach (DateData data in OrderItem.Lecture.Datas)
            {
                DateDataObject dateDataObject = Instantiate(Prefab, transform);
                dateDataObject.Init(data, this);
                Vector2 position = dateDataObject.Rect.anchoredPosition;
                position.y = -totalHeight;
                dateDataObject.Rect.anchoredPosition = position;
                DataObjects.Add(dateDataObject);
                if (data.HasDate)
                {
                    dateDataObject.SetData(data.DateTime, data.Hours);
                }
                else
                {
                    dateDataObject.SetData(data.Hours);
                }

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
            size.y = 100;
            if (DataObjects.Count > 0)
            {
                size.y += DataObjects.Count * 80;
            }
            else
            {
                size.y += 80;
            }
            
            Rect.sizeDelta = size;
            OnRecalculateContent.Invoke();
        }

        public void AddNewDateData()
        {
            DateDataObject dataObject = Instantiate(Prefab, transform);
            Vector2 position = dataObject.Rect.anchoredPosition;
            position.y = -(20 + DataObjects.Count * 80);
            dataObject.Rect.anchoredPosition = position;
            AddButton.anchoredPosition = position;
            DateData dateData = new DateData();
            dataObject.Data = dateData;
            OrderItem.Lecture.Datas.Add(dateData);
            DataObjects.Add(dataObject);
            dataObject.Init(dateData, this);
            RecalculateContent();
        }

        public void OnRemoveObject(DateDataObject dateDataObject)
        {
            Lecture.Datas.Remove(dateDataObject.Data);
            DataObjects.Remove(dateDataObject);
            Destroy(dateDataObject.gameObject);
            RecalculateContent();
        }
    }
}