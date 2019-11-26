using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherListSO : MonoBehaviour, ITeachersProxy
{
    public List<Teacher> TeachersList;

    public List<Teacher> Teachers => TeachersList;
}
