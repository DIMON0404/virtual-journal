using System;
using System.Collections.Generic;

[Serializable]
public class GeneralData
{
    public int CathedraCode;
    public string DisciplineName;
    public LessonTypeEnum LessonType;
    public ExamTypeEnum ExamType;
    public HoursData HoursData;

    public GeneralData()
    {
        HoursData = new HoursData();
        CathedraCode = -1;
    }


    public static Dictionary<LessonTypeEnum, string> LessonTypeData = new Dictionary<LessonTypeEnum, string>
    {
        {
            LessonTypeEnum.Lecture, "Лекція"
        },
        {
            LessonTypeEnum.Practice, "Практика"
        }
    };

    public static Dictionary<ExamTypeEnum, string> ExamTypeData = new Dictionary<ExamTypeEnum, string>
    {
        {
            ExamTypeEnum.Exam, "Екзамен"
        },
        {
            ExamTypeEnum.Credit, "Залік"
        }
    };

    public enum LessonTypeEnum
    {
        Lecture = 1,
        Practice
    }

    public enum ExamTypeEnum
    {
        Exam = 1,
        Credit
    }
}
