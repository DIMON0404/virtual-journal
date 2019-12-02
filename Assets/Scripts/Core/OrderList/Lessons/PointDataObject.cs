using System;
using Core.OrderList;
using Journal_Model.Core;
using Journal_Model.Lesson;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PointDataObject : MonoBehaviour
    {
        public PointData PointData;
        public RectTransform Rect;
        private IObjectRemover<PointDataObject> LessonDetailObject;
        private Action UpdateData;
        [SerializeField] private InputField ID;
        [SerializeField] private InputField PointName;
        
        public void Init(PointData pointData, IObjectRemover<PointDataObject> lessonDetailObject, Action update)
        {
            PointData = pointData;
            LessonDetailObject = lessonDetailObject;
            UpdateData = update;
        }

        public void SetData(int id, string pointName)
        {
            SetID(id);
            SetName(pointName);
        }

        public void SetID(int id)
        {
            ID.text = id.ToString();
        }

        public void OnIDChanged(int id)
        {
            PointData.ID = id;
            UpdateData.Invoke();
        }

        public void OnNameChanged(string name)
        {
            PointData.Name = name;
        }

        public void SetName(string pointName)
        {
            PointName.text = pointName;
        }

        public void OnRemoveThis()
        {
            LessonDetailObject.OnRemoveObject(this);
        }
    }
}