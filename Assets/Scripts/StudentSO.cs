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
    }
}