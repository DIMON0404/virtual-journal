using System;

namespace UI_Controllers.Introducing
{
    public class ExamTypeDropDown : DropDownAbstract<GeneralData.ExamTypeEnum>
    {
        protected override void OnChangedEnum(int item)
        {
            JournalModelProxy.JournalModel.GeneralData.ExamType = (GeneralData.ExamTypeEnum) item;
        }

        protected override string GetItemName(string item)
        {
            return GeneralData.ExamTypeData[(GeneralData.ExamTypeEnum)Enum.Parse(typeof(GeneralData.ExamTypeEnum), item)];
        }
    }
}