using UnityEngine;
using UnityEngine.UI;

namespace UI_Controllers.Introducing
{
    public class CathedraCodeController : MonoBehaviour
    {
        [SerializeField] private JournalModelProxy JournalModelProxy;
        [SerializeField] private InputField InputField;

        public void OnEdit()
        {
            int parsed;
            if (int.TryParse(InputField.text, out parsed))
            {
                JournalModelProxy.JournalModel.GeneralData.CathedraCode = parsed;
            }
        }

        public void OnChangeEnd()
        {
            int parsed;
            if (int.TryParse(InputField.text, out parsed))
            {
                JournalModelProxy.JournalModel.GeneralData.CathedraCode = parsed;
            }
            else
            {
                InputField.text = JournalModelProxy.JournalModel.GeneralData.CathedraCode.ToString();
            }
        }
    }
}
