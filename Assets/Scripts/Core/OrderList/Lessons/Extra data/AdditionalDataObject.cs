using System;
using System.Collections.Generic;
using DefaultNamespace;
using Journal_Model.Core;
using Journal_Model.Lesson;
using UnityEngine;

namespace Core.OrderList.Lessons.Extra_data
{
    public class AdditionalDataObject : OrderItemObject<PointsItem>, IObjectRemover<PointDataObject>
    {
        [SerializeField] private RectTransform AddButton;
        public Action OnRecalculateContent;
        public Action OnSelectThis;

        public Journal_Model.Journal_Model.AdditionalPoints AdditionalPoints => OrderItem.PointsData;
        public PointDataObject Prefab;
        public List<PointDataObject> PointDatas;
        
        public void OnInit()
        {
            int totalHeight = 180;
            if (AdditionalPoints.Points.Count > 0)
            {
                totalHeight -= 80;
            }
            
            ResortItems();
            foreach (PointData data in AdditionalPoints.Points)
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
            PointData pointData = new PointData();
            dataObject.PointData = pointData;
            AdditionalPoints.Points.Add(pointData);
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
            AdditionalPoints.Points.Remove(pointDataObject.PointData);
            PointDatas.Remove(pointDataObject);
            Destroy(pointDataObject.gameObject);
            UpdateData();
        }
        
        public void ResortItems()
        {
            AdditionalPoints.Points.Sort((item1, item2) =>
                (item1.ID > item2.ID) ? 1 : (item1.ID < item2.ID ? -1 : 0));
            for (int i = 0; i < AdditionalPoints.Points.Count; i++)
            {
                AdditionalPoints.Points[i].ID = i + 1;
            }
        }

        public void SelectThis()
        {
            OnSelectThis.Invoke();
        }
    }
}