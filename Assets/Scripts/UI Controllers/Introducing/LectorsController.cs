using System.Collections.Generic;

namespace UI_Controllers.Introducing
{
    public class LectorsController : TeacherControllerAbstract
    {
        protected override List<Teacher> TeachersList
        {
            get { return JournalModel.JournalModel.Lectors; }
            set { JournalModel.JournalModel.Lectors = value; }
        }
    }
}