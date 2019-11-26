using Journal_Model;
using Utility;

namespace Core.OrderList
{
    public class LectureItem : OrderItem
    {
        public LectureTheme Lecture;

        public LectureItem() : this(new LectureTheme())
        {
        }

        public LectureItem(LectureTheme lecture)
        {
            Lecture = lecture;
        }
    }
}