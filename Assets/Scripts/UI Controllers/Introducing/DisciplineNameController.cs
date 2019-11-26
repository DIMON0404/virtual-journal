using UnityEngine;
using UnityEngine.UI;

namespace UI_Controllers.Introducing
{
    public class DisciplineNameController : MonoBehaviour
    {
        [SerializeField] private JournalModelProxy JournalModelProxy;
        [SerializeField] private InputField InputField;

        public void OnEdit()
        {
            JournalModelProxy.JournalModel.GeneralData.DisciplineName = InputField.text;
        }
    }
}
