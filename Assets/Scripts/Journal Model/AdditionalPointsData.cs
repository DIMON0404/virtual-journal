using System.Collections.Generic;
using Journal_Model.Lesson;

namespace Journal_Model.Journal_Model
{
    public class AdditionalPointsData
    {
        public AdditionalPoints AdditionalPoints;
        public Dictionary<StudentSO, Dictionary<PointData, float>> Points;

        public AdditionalPointsData()
        {
            Points = new Dictionary<StudentSO, Dictionary<PointData, float>>();
            AdditionalPoints = new AdditionalPoints();
        }
    }
}