using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI_Controllers.Introducing
{
    public class TeacherController : TeacherControllerAbstract
    {
        [SerializeField] protected Content Teachers;
        
        protected override List<Teacher> TeachersList
        {
            get { return JournalModel.JournalModel.Teachers; }
            set { JournalModel.JournalModel.Teachers = value; }
        }
        
        public override void UpdateTeachersView()
        {
        
            Teachers.SetItems(TeachersList.Select(item => item as ItemSO).ToList());
        }
    }
}
