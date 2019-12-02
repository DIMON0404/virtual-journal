using System;
using System.Collections.Generic;
using Journal_Model.LessonThemes;

namespace Journal_Model.Lesson
{
    [Serializable]
    public class Lesson
    {
        public Dictionary<StudentSO, LessonData> Datas;
        public LessonTheme LessonTheme;
        
        public Lesson()
        {
            Datas = new Dictionary<StudentSO, LessonData>();
        }
    }
}