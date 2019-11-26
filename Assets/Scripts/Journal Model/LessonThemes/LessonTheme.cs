using System;
using System.Collections.Generic;
using Utility;

namespace Journal_Model.LessonThemes
{
    [Serializable]
    public class LessonTheme
    {
        public int ID;
        public string Name;
        public List<TeacherData> TeacherDatas;

        public LessonTheme()
        {
            TeacherDatas = new List<TeacherData>();
        }
    }
}