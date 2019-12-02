using System.Collections.Generic;
using Journal_Model.Lesson;
using UnityEngine;

namespace Journal_Model
{
    [CreateAssetMenu(fileName = "Item", menuName = "SO/Student")]
    public class StudentSO : ScriptableObject
    {
        public string Name;
        public string SurName;
        public string Patronymic;
        public GroupData GroupData;

        public string ToShortNSP()
        {
            return SurName +
                   (string.IsNullOrEmpty(Name) ? string.Empty : (" " + Name[0] + ".")) +
                   (string.IsNullOrEmpty(Patronymic) ? string.Empty : (" " + Patronymic[0] + "."));
        }
    }
}