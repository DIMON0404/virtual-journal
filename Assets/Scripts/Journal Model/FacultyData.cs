using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacultyData
{
    public static Dictionary<Faculty, FacultyName> Faculties = new Dictionary<Faculty, FacultyName>()
    {
        {
            Faculty.FMTP, new FacultyName(
                "Факультет міжнародної торгівлі та права",
                "ФМТП")
        },
        {
            Faculty.FTM, new FacultyName(
                "Факультет торігвлі та маркетингу",
                "ФТМ")
        },
        {
            Faculty.FEMP, new FacultyName(
                "Факльутет економіки, менеджменту та права",
                "ФЕМП")
        },
        {
            Faculty.FRGTB, new FacultyName(
                "Факультет готельно-ресторанного бізнесу",
                "ФРГТБ")
        },
        {
            Faculty.FOAIS, new FacultyName(
                "Факультет обліку, аудиту та інформаційних систем",
                "ФОАІС")
        },
        {
            Faculty.FFBS, new FacultyName(
                "Факультет фінансів на банківської справи",
                "ФФБС")
        }
    };

    public enum Faculty
    {
        FMTP = 1,
        FTM,
        FEMP,
        FRGTB,
        FOAIS,
        FFBS
    }
    
    public struct FacultyName
    {
        public string FullName;
        public string ShrotName;

        public FacultyName(string fullName, string shrotName)
        {
            FullName = fullName;
            ShrotName = shrotName;
        }
    }
}
