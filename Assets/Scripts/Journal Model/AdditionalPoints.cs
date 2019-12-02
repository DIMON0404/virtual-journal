using System;
using System.Collections.Generic;
using Journal_Model.Lesson;

namespace Journal_Model.Journal_Model
{
    [Serializable]
    public class AdditionalPoints
    {
        public List<PointData> Points;

        public AdditionalPoints()
        {
            Points = new List<PointData>();
        }
    }
}