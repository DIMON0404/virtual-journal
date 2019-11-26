using System;

namespace UI_Controllers.Introducing
{
    public class FacultyDropDown : DropDownAbstract<FacultyData.Faculty>
    {
        protected override void OnChangedEnum(int item)
        {
            JournalModelProxy.JournalModel.GroupData.Faculty = (FacultyData.Faculty)item;
        }

        protected override string GetItemName(string item)
        {
            return FacultyData.Faculties[(FacultyData.Faculty) Enum.Parse(typeof(FacultyData.Faculty), item)].ShrotName;
        }
    }
}