using System;

namespace UI_Controllers.Introducing
{
    public class LessonTypeDropDown : DropDownAbstract<GeneralData.LessonTypeEnum>
    {
        protected override void OnChangedEnum(int item)
        {
            JournalModelProxy.JournalModel.GeneralData.LessonType = (GeneralData.LessonTypeEnum) item;
        }

        protected override string GetItemName(string item)
        {
            return GeneralData.LessonTypeData[(GeneralData.LessonTypeEnum)Enum.Parse(typeof(GeneralData.LessonTypeEnum), item)];
        }
    }
}
