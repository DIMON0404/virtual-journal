using UnityEngine;
using UnityEngine.UI;

namespace UI_Controllers.Introducing
{
    public class CourseController : MonoBehaviour
    {
        [SerializeField] private Dropdown Dropdown;
        [SerializeField] private JournalModelProxy JournalModelProxy;
    
        public void OnValueChange(int index)
        {
            JournalModelProxy.JournalModel.GroupData.Course = int.Parse(Dropdown.options[index].text);
        }
    }
}
