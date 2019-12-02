namespace Core.OrderList.LectureTheme
{
    public class LectureItem : OrderItem
    {
        public Journal_Model.LectureTheme Lecture;

        public LectureItem() : this(new Journal_Model.LectureTheme())
        {
        }

        public LectureItem(Journal_Model.LectureTheme lecture)
        {
            Lecture = lecture;
        }
    }
}