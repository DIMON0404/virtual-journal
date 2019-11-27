using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Controllers.Introducing
{
    public class LectorsController : TeacherControllerAbstract
    {
        [SerializeField] private Text Text;

        protected override List<Teacher> TeachersList
        {
            get { return new List<Teacher> {JournalModel.JournalModel.Lector}; }
            set { JournalModel.JournalModel.Lector = (value == null || value.Count == 0) ? null : value[0] ; }
        }
        
        public override void UpdateTeachersView()
        {
            Teacher lector = JournalModel.JournalModel.Lector;
            Text.text = lector != null ? lector.ToString() : "";
        }
    }
}