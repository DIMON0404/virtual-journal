using UI_Controllers;
using UnityEngine;

namespace Core.OrderList.Lesson
{
    public class LessonList : OrderList<LessonItem, LessonItemObject>
    {
        [SerializeField] private JournalModelProxy JournalModelProxy;
        public override void InitializeNewItemObject(LessonItemObject itemObject)
        {
            base.InitializeNewItemObject(itemObject);
            itemObject.OnIdChagned = UpdateItems;
            itemObject.OnRecalculateContent = UpdateItems;
            itemObject.Teachers = JournalModelProxy.JournalModel.Teachers;
            itemObject.OnInit();
        }

        public override void UpdateItems()
        {
            ResortItems();
            base.UpdateItems();
            JournalModelProxy.JournalModel.LectureThemes.Clear();
            foreach (LessonItem item in OrderItems)
            {
                JournalModelProxy.JournalModel.LessonThemes.Add(item.Lesson);
            }
        }

        public override LessonItem GetItemForAdd()
        {
            LessonItem item = base.GetItemForAdd();
            item.Lesson.ID = OrderItems.Count;
            return item;
        }

        public void ResortItems()
        {
            OrderItems.Sort((item1, item2) =>
                (item1.Lesson.ID > item2.Lesson.ID) ? 1 : (item1.Lesson.ID < item2.Lesson.ID ? -1 : 0));
            for (int i = 0; i < OrderItems.Count; i++)
            {
                OrderItems[i].Lesson.ID = i + 1;
            }
        }
    }
}