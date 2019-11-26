using System;
using Utility;

namespace Journal_Model
{
    [Serializable]
    public class DateData
    {
        public int Hours;
        public bool HasDate;
        public DateTimeHolder DateTime;

        public DateData()
        {
            DateTime = System.DateTime.Now;
        }
    }
}