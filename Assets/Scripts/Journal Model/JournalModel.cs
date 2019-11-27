using System;
using System.Collections;
using System.Collections.Generic;
using Journal_Model;
using Journal_Model.LessonThemes;
using UnityEngine;

[Serializable]
public class JournalModel
{
    public GroupData GroupData;
    public List<Teacher> Teachers;
    public Teacher Lector;

    public GeneralData GeneralData;
    public List<LectureTheme> LectureThemes;
    public List<LessonTheme> LessonThemes;

    public JournalModel()
    {
        Teachers = new List<Teacher>();
        GroupData = new GroupData();
        GeneralData = new GeneralData();
        LectureThemes = new List<LectureTheme>();
        LessonThemes = new List<LessonTheme>();
    }
}
