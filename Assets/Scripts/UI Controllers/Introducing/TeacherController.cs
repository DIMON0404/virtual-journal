using System.Collections.Generic;

namespace UI_Controllers.Introducing
{
    public class TeacherController : TeacherControllerAbstract
    {
        protected override List<Teacher> TeachersList
        {
            get { return JournalModel.JournalModel.Teachers; }
            set { JournalModel.JournalModel.Teachers = value; }
        }
    }
}
