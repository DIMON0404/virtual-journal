﻿using System;
using System.Collections;
using System.Collections.Generic;
using Journal_Model;
using Journal_Model.Journal_Model;
using Journal_Model.Lesson;
using Journal_Model.LessonThemes;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class JournalModel
{
    public GroupData GroupData;
    public List<Teacher> Teachers;
    public List<StudentSO> Students;
    public Teacher Lector;

    public GeneralData GeneralData;
    public List<LectureTheme> LectureThemes;
    public List<LessonTheme> LessonThemes;
    public List<Lesson> Lessons;
    public AdditionalPoints ExtraPoints;
    public AdditionalPoints ModulePoints;
    public AdditionalPointsData ExtraPointsData;
    public AdditionalPointsData ModulePointsData;

    public JournalModel()
    {
        Teachers = new List<Teacher>();
        GroupData = new GroupData();
        GeneralData = new GeneralData();
        LectureThemes = new List<LectureTheme>();
        LessonThemes = new List<LessonTheme>();
        Lessons = new List<Lesson>();
        ExtraPoints = new AdditionalPoints();
        ModulePoints = new AdditionalPoints();
        ExtraPointsData = new AdditionalPointsData();
        ModulePointsData = new AdditionalPointsData();
        ExtraPointsData.AdditionalPoints = ExtraPoints;
        ModulePointsData.AdditionalPoints = ModulePoints;
        Students = new List<StudentSO>();
    }
}
