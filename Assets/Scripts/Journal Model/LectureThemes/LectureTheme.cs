using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Journal_Model
{
    [Serializable]
    public class LectureTheme
    {
        public int ID;
        public string Name;
        public List<DateData> Datas;

        public LectureTheme()
        {
            Datas = new List<DateData>();
        }
    }
}