using Core.OrderList;
using Core.OrderList.LectureTheme;
using UI_Controllers;
using UnityEngine;
using System.Linq;
using Core.OrderList.Lessons.Extra_data;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class LessonsDetailList : OrderList<LessonItem, LessonDetailObject>
    {
        [SerializeField] private JournalModelProxy JournalModelProxy;
        private AdditionalDataObject ExtraPointsObject;
        [SerializeField] private AdditionalDataObject ExtraPointsObjectPrefab;
        private AdditionalDataObject ModulePointsObject;
        [SerializeField] private AdditionalDataObject ModulePointsObjectPrefab;
        public override void InitializeNewItemObject(LessonDetailObject itemObject)
        {
            base.InitializeNewItemObject(itemObject);
            itemObject.OnRecalculateContent = UpdateItems;
            itemObject.OnInit();
        }

        public override void UpdateItems()
        {
            OrderItems = JournalModelProxy.JournalModel.LessonThemes.Select(lesson => new LessonItem(lesson)).ToList();
            if (ExtraPointsObject != null)
            {
                Destroy(ExtraPointsObject.gameObject);
            }

            ExtraPointsObject = Instantiate(ExtraPointsObjectPrefab, AdditionalData);
            ExtraPointsObject.OnRecalculateContent = UpdateItems;
            ExtraPointsObject.OrderItem = new PointsItem
                {PointsData = JournalModelProxy.JournalModel.ExtraPoints};
            ExtraPointsObject.OnInit();            
            if (ModulePointsObject != null)
            {
                Destroy(ModulePointsObject.gameObject);
            }

            ModulePointsObject = Instantiate(ModulePointsObjectPrefab, AdditionalData);
            ModulePointsObject.OnRecalculateContent = UpdateItems;
            ModulePointsObject.OrderItem = new PointsItem
                {PointsData = JournalModelProxy.JournalModel.ModulePoints};
            ModulePointsObject.OnInit();
            Vector2 mcwPosition = ModulePointsObject.Rect.anchoredPosition;
            mcwPosition.y = ExtraPointsObject.Rect.anchoredPosition.y - ExtraPointsObject.Rect.sizeDelta.y;
            ModulePointsObject.Rect.anchoredPosition = mcwPosition;
            Vector2 sizeDelta = AdditionalData.sizeDelta;
            sizeDelta.y = ExtraPointsObject.Rect.sizeDelta.y + ModulePointsObject.Rect.sizeDelta.y;
            AdditionalData.sizeDelta = sizeDelta;
            base.UpdateItems();
        }

        public override LessonItem GetItemForAdd()
        {
            LessonItem item = base.GetItemForAdd();
            item.Lesson.ID = OrderItems.Count;
            return item;
        }
    }
}