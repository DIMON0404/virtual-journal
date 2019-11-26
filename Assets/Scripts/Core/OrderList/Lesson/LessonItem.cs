using Journal_Model.LessonThemes;

namespace Core.OrderList.Lesson
{
    public class LessonItem : OrderItem
    {
        public LessonTheme Lesson;

        public LessonItem() : this(new LessonTheme())
        {
        }

        public LessonItem(LessonTheme lesson)
        {
            Lesson = lesson;
        }
    }
}