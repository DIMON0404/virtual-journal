using UnityEngine;
using UnityEngine.UI;

namespace Journal_Model.Core
{
    public class StudentTotalPanel : MonoBehaviour
    {
        public RectTransform Rect;
        [SerializeField] private Text Name;
        [SerializeField] private Text LessonsText;
        [SerializeField] private Text ExtraPointsText;
        [SerializeField] private Text ModuleControlWorkText;
        [SerializeField] private Text TotalText;
        
        public void Init(string name, string lessons, string extra, string module, string total)
        {
            Name.text = name;
            LessonsText.text = lessons;
            ExtraPointsText.text = extra;
            ModuleControlWorkText.text = module;
            TotalText.text = total;
        }
    }
}