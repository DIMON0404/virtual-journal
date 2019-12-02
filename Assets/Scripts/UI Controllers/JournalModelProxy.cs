using System.Collections.Generic;
using Journal_Model;
using UnityEngine;

namespace UI_Controllers
{
    public class JournalModelProxy : MonoBehaviour, IInitable
    {
        public JournalModel JournalModel;
        public List<StudentSO> Students;

        public void Init()
        {
            JournalModel = new JournalModel();
            JournalModel.Students = Students;
        }
    }
}