using System;
using System.Collections.Generic;
using Core.OrderList;
using Journal_Model.Core;
using Journal_Model.Lesson;
using Journal_Model.LessonThemes;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LessonDetailObject : OrderItemObject<LessonItem>, IObjectRemover<PointDataObject>
    {
        [SerializeField] private Text ID;
        [SerializeField] private Text LessonName;
        [SerializeField] private RectTransform AddButton;
        public Action OnRecalculateContent;
        public Action OnSelectThis;
        public LessonTheme LessonTheme => OrderItem.Lesson;
        public PointDataObject Prefab;
        public List<PointDataObject> PointDatas;
        
        public void OnInit()
        {
            ID.text = LessonTheme.ID.ToString();
            LessonName.text = LessonTheme.Name;
            int totalHeight = 180;
            if (LessonTheme.PointDatas.Count > 0)
            {
                totalHeight -= 80;
            }

            ResortItems();
            foreach (PointData data in LessonTheme.PointDatas)
            {
                PointDataObject dataObject = Instantiate(Prefab, transform);
                dataObject.Init(data, this, UpdateData);
                Vector2 position = dataObject.Rect.anchoredPosition;
                position.y = -totalHeight;
                dataObject.Rect.anchoredPosition = position;
                PointDatas.Add(dataObject);
                dataObject.SetData(data.ID, data.Name);
                totalHeight += 80;
            }

            Vector2 positionButton = AddButton.anchoredPosition;
            positionButton.y = -totalHeight + 80;
            AddButton.anchoredPosition = positionButton;
            Vector2 size = Rect.sizeDelta;
            size.y = totalHeight;
            Rect.sizeDelta = size;
        }
        
        public void AddNewPointData()
        {
            PointDataObject dataObject = Instantiate(Prefab, transform);
            Vector2 position = dataObject.Rect.anchoredPosition;
            position.y = -(20 + PointDatas.Count * 80);
            dataObject.Rect.anchoredPosition = position;
            AddButton.anchoredPosition = position;
            PointData pointData = new PointData();
            dataObject.PointData = pointData;
            LessonTheme.PointDatas.Add(pointData);
            PointDatas.Add(dataObject);
            pointData.ID = PointDatas.Count;
            UpdateData();
        }
        
        public void UpdateData()
        {
            OnRecalculateContent.Invoke();
        }

        public void OnRemoveObject(PointDataObject pointDataObject)
        {
            LessonTheme.PointDatas.Remove(pointDataObject.PointData);
            PointDatas.Remove(pointDataObject);
            Destroy(pointDataObject.gameObject);
            UpdateData();
        }
        
        public void ResortItems()
        {
            LessonTheme.PointDatas.Sort((item1, item2) =>
                (item1.ID > item2.ID) ? 1 : (item1.ID < item2.ID ? -1 : 0));
            for (int i = 0; i < LessonTheme.PointDatas.Count; i++)
            {
                LessonTheme.PointDatas[i].ID = i + 1;
            }
        }
        
        public void SelectThis()
        {
            OnSelectThis.Invoke();
        }
    }
}
