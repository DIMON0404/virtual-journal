namespace Core.OrderList
{
    public class LessonItem : OrderItem
    {
        public Journal_Model.LessonThemes.LessonTheme Lesson;

        public LessonItem() : this(new Journal_Model.LessonThemes.LessonTheme())
        {
        }

        public LessonItem(Journal_Model.LessonThemes.LessonTheme lesson)
        {
            Lesson = lesson;
        }
    }
}