using System;
using System.Collections;
using System.Collections.Generic;
using Journal_Model;
using UnityEngine;

[Serializable]
public class GroupData
{
    [SerializeField] private FacultyData.Faculty m_Faculty;

    public FacultyData.Faculty Faculty
    {
        get { return m_Faculty; }
        set
        {
            m_Faculty = value;
            UpdateStringData();
        }
    }

    [SerializeField] private int m_Course;

    public int Course
    {
        get { return m_Course; }
        set
        {
            m_Course = value;
            UpdateStringData();
        }
    }

    [SerializeField] private int m_Group;

    public int Group
    {
        get { return m_Group; }
        set
        {
            m_Group = value;
            UpdateStringData();
        }
    }

    [SerializeField] private bool m_Mastery;

    public bool Mastery
    {
        get
        {
            return m_Mastery;
        }
        set
        {
            m_Mastery = value;
            UpdateStringData();
        }
    }

    [SerializeField] private string StringData;

    public List<StudentSO> Students;

    private void UpdateStringData()
    {
        StringData = 
            (Faculty == 0 
                ? string.Empty 
                : FacultyData.Faculties[Faculty].ShrotName) + " " + Course + "-" + Group + (m_Mastery ? "м" : "");
    }

    public GroupData()
    {
        Students = new List<StudentSO>();
    }

    public override string ToString()
    {
        return StringData;
    }
}