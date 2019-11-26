using UI_Controllers;
using UnityEngine;

namespace Core.OrderList
{
    public class LectureList : OrderList<LectureItem, LectureItemObject>
    {
        [SerializeField] private JournalModelProxy JournalModelProxy;
        public override void InitializeNewItemObject(LectureItemObject itemObject)
        {
            base.InitializeNewItemObject(itemObject);
            itemObject.OnIdChagned = UpdateItems;
            itemObject.OnRecalculateContent = UpdateItems;
            itemObject.OnInit();
        }

        public override void UpdateItems()
        {
            ResortItems();
            base.UpdateItems();
            JournalModelProxy.JournalModel.LectureThemes.Clear();
            foreach (LectureItem item in OrderItems)
            {
                JournalModelProxy.JournalModel.LectureThemes.Add(item.Lecture);
            }
        }

        public override LectureItem GetItemForAdd()
        {
            LectureItem item = base.GetItemForAdd();
            item.Lecture.ID = OrderItems.Count;
            return item;
        }

        public void ResortItems()
        {
            OrderItems.Sort((item1, item2) =>
                (item1.Lecture.ID > item2.Lecture.ID) ? 1 : (item1.Lecture.ID < item2.Lecture.ID ? -1 : 0));
            for (int i = 0; i < OrderItems.Count; i++)
            {
                OrderItems[i].Lecture.ID = i + 1;
            }
        }
    }
}