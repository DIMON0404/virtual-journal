using UnityEngine;

namespace UI_Controllers
{
    public class JournalModelProxy : MonoBehaviour, IInitable
    {
        public JournalModel JournalModel;

        public void Init()
        {
            JournalModel = new JournalModel();
        }
    }
}