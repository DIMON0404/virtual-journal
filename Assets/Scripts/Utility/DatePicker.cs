using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utility
{
    public class DatePicker : MonoBehaviour
    {
        private DateTimeHolder SelectedDate = new DateTimeHolder{DateTime = DateTime.Now};
        private DateTime LastDateTime = DateTime.Now;
        [SerializeField] private StringUnityEvent OnDateChanged;

#if UNITY_ANDROID && !UNITY_EDITOR
        
        class DateCallback : AndroidJavaProxy
        {
            private DateTimeHolder selectedDate;

            public DateCallback(DateTimeHolder dateTime) : base("android.app.DatePickerDialog$OnDateSetListener")
            {
                selectedDate = dateTime;
            }

            void onDateSet(AndroidJavaObject view, int year, int monthOfYear, int dayOfMonth)
            {
                selectedDate.DateTime = new DateTime(year, monthOfYear + 1, dayOfMonth);
            }
        }
#endif

        public void SelectDate()
        {
#if UNITY_EDITOR
            CustomDataPicker.Instance.PickDate(time => SelectedDate.DateTime = time);
#elif UNITY_ANDROID
            AndroidJavaObject activity =
                new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call("runOnUiThread",
                new AndroidJavaRunnable(() =>
                {
                    new AndroidJavaObject("android.app.DatePickerDialog", activity, new DateCallback(SelectedDate),
                        SelectedDate.DateTime.Year, SelectedDate.DateTime.Month - 1, SelectedDate.DateTime.Day).Call("show");
                }));
#endif
        }

        private void Update()
        {
            if (SelectedDate.DateTime != LastDateTime)
            {
                LastDateTime = SelectedDate.DateTime;
                DataChanged();
            }
        }

        private void DataChanged()
        {
            OnDateChanged.Invoke(SelectedDate.DateTime);
        }

        [Serializable]
        private class StringUnityEvent : UnityEvent<DateTime>
        {}
    }
}