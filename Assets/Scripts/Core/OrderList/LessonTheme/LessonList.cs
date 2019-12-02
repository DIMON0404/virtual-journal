using System.Collections.Generic;
using System.Linq;
using Journal_Model.Lesson;
using UI_Controllers;
using UnityEngine;

namespace Core.OrderList.LessonTheme
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
            JournalModelProxy.JournalModel.LessonThemes.Clear();
            List<Lesson> listForRemoving = new List<Lesson>(JournalModelProxy.JournalModel.Lessons);
            foreach (LessonItem item in OrderItems)
            {
                JournalModelProxy.JournalModel.LessonThemes.Add(item.Lesson);
                if (JournalModelProxy.JournalModel.Lessons.All(lesson => lesson.LessonTheme != item.Lesson))
                {
                    JournalModelProxy.JournalModel.Lessons.Add(new Lesson(){LessonTheme = item.Lesson});
                }

                Lesson lessonForRemoving = listForRemoving.FirstOrDefault(lesson => lesson.LessonTheme == item.Lesson);
                if (lessonForRemoving != null)
                {
                    listForRemoving.Remove(lessonForRemoving);
                }
            }

            foreach (Lesson item in listForRemoving)
            {
                JournalModelProxy.JournalModel.Lessons.Remove(item);
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