using System;
using System.Collections.Generic;
using Journal_Model.Lesson;
using Utility;

namespace Journal_Model.LessonThemes
{
    [Serializable]
    public class LessonTheme
    {
        public int ID;
        public string Name;
        public List<TeacherData> TeacherDatas;
        public List<PointData> PointDatas;

        public LessonTheme()
        {
            TeacherDatas = new List<TeacherData>();
            PointDatas = new List<PointData>();
        }
    }
}