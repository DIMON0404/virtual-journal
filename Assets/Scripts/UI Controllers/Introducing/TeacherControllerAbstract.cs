using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI_Controllers.Introducing
{
    public abstract class TeacherControllerAbstract : MonoBehaviour
    {
        [SerializeField] protected JournalModelProxy JournalModel;
        [SerializeField] protected Content Teachers;
        [SerializeField] protected TeacherSelectionPanel SelectionPanel;
        [ValidateField(typeof(ITeachersProxy))][SerializeField] protected Object TeachersProxy;
        protected ITeachersProxy TeachersProxyGetter => TeachersProxy as ITeachersProxy;

        protected abstract List<Teacher> TeachersList { get; set; }

        public void UpdateTeachersView()
        {
        
            Teachers.SetItems(TeachersList.Select(item => item as ItemSO).ToList());
        }

        public void UpdateTeachersList(List<Teacher> teachers)
        {
            TeachersList = teachers;
        }

        public void SetSelectionPanelItems()
        {
            SelectionPanel.Init(this, TeachersProxyGetter.Teachers.ToArray(), TeachersList.ToArray());
        }
    }
}