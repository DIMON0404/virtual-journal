using UnityEngine;
using UnityEngine.UI;

namespace UI_Controllers.Introducing
{
    public class GroupController : MonoBehaviour
    {
        [SerializeField] private JournalModelProxy JournalModelProxy;

        public void OnValueChange(int value)
        {
            JournalModelProxy.JournalModel.GroupData.Group = value;
        }
        
        
        public void SetMaster(bool isMaster)
        {
            JournalModelProxy.JournalModel.GroupData.Mastery = isMaster;
        }
    }
}
