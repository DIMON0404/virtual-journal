using System.Collections.Generic;

namespace Journal_Model.Lesson
{
    public class Lesson
    {
        public Dictionary<StudentSO, LessonData> Datas;

        public Lesson()
        {
            Datas = new Dictionary<StudentSO, LessonData>();
        }
    }
}