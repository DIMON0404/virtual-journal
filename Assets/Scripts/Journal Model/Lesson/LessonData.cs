using System.Collections.Generic;

namespace Journal_Model.Lesson
{
    public class LessonData
    {
        public bool IsPresence;
        public Dictionary<PointData, float> Points;

        public LessonData()
        {
            Points = new Dictionary<PointData, float>();
        }
    }
}