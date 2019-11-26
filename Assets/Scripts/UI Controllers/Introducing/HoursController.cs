using UnityEngine;
using UnityEngine.UI;

namespace UI_Controllers.Introducing
{
    public class HoursController : MonoBehaviour
    {
        [SerializeField] private JournalModelProxy JournalModelProxy;
        [SerializeField] private Text TotalText;
        [SerializeField] private Text CreditsText;

        public int LectureHours
        {
            get { return JournalModelProxy.JournalModel.GeneralData.HoursData.Lectures; }
            set
            {
                JournalModelProxy.JournalModel.GeneralData.HoursData.Lectures = value;
                CalculateTotalEndCredits();
            }
        }

        public int PracticalHours
        {
            get { return JournalModelProxy.JournalModel.GeneralData.HoursData.PracticeLessons; }
            set
            {
                JournalModelProxy.JournalModel.GeneralData.HoursData.PracticeLessons = value;
                CalculateTotalEndCredits();
            }
        }

        public int SeminarHours
        {
            get { return JournalModelProxy.JournalModel.GeneralData.HoursData.Seminars; }
            set
            {
                JournalModelProxy.JournalModel.GeneralData.HoursData.Seminars = value;
                CalculateTotalEndCredits();
            }
        }
        
        public int IndividualHours
        {
            get { return JournalModelProxy.JournalModel.GeneralData.HoursData.IndividualWork; }
            set
            {
                JournalModelProxy.JournalModel.GeneralData.HoursData.IndividualWork = value;
                CalculateTotalEndCredits();
            }
        }
        
        public int ExamHours
        {
            get { return JournalModelProxy.JournalModel.GeneralData.HoursData.Exam; }
            set
            {
                JournalModelProxy.JournalModel.GeneralData.HoursData.Exam = value;
                CalculateTotalEndCredits();
            }
        }
        
        public int SelfWorkHours
        {
            get { return JournalModelProxy.JournalModel.GeneralData.HoursData.SelfWork; }
            set
            {
                JournalModelProxy.JournalModel.GeneralData.HoursData.SelfWork = value;
                CalculateTotalEndCredits();
            }
        }

        private void CalculateTotalEndCredits()
        {
            int total = LectureHours
                        + PracticalHours
                        + SeminarHours
                        + IndividualHours
                        + ExamHours
                        + SelfWorkHours;
            int credits = total / 36;
            TotalText.text = total.ToString();
            CreditsText.text = credits.ToString();
            JournalModelProxy.JournalModel.GeneralData.HoursData.Total = total;
            JournalModelProxy.JournalModel.GeneralData.HoursData.Credits = credits;
        }
    }
}
