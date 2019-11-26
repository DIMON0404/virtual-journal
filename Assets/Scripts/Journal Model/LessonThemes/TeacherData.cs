using System;
using Utility;

namespace Journal_Model.LessonThemes
{
    [Serializable]
    public class TeacherData
    {
        public Teacher teacher;
        public bool HasData;
        public DateTimeHolder DateTime;
    }
}