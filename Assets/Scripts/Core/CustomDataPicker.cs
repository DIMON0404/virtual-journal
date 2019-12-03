using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomDataPicker : MonoBehaviour
{
    public static CustomDataPicker Instance;
    
    [SerializeField] private InputField Year;
    [SerializeField] private InputField Month;
    [SerializeField] private InputField Day;
    [SerializeField] private Text Text;
    private DateTime DateTime;
    private int LastYear;
    private int LastMonth;
    private int LastDay;

    private Action<DateTime> OnDatePicked;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void PickDate(Action<DateTime> OnSelect)
    {
        OnDatePicked = OnSelect;
        DateTime = DateTime.Now;
        LastYear = DateTime.Year;
        LastMonth = DateTime.Month;
        LastDay = DateTime.Day;
        gameObject.SetActive(true);
        ResetYear();
        ResetMonth();
        ResetDay();
    }
    
    public void OnYearChanged(string year)
    {
        int yearInt;
        if (int.TryParse(year, out yearInt) && yearInt >= 0)
        {          
            DateTime dayTime;
            if (TrySetData(yearInt, DateTime.Month, DateTime.Day, out dayTime))
            {
                DateTime = dayTime;
                LastYear = yearInt;
            }
        }

        ResetYear();
    }
    
    public void OnMonthChanged(string month)
    {
        int monthInt;
        if (int.TryParse(month, out monthInt) && monthInt >= 0)
        {            
            DateTime dayTime;
            if (TrySetData(DateTime.Year, monthInt, DateTime.Day, out dayTime))
            {
                DateTime = dayTime;
                LastMonth = monthInt;
            }
        }

        ResetMonth();
    }
    
    public void OnDayChanged(string day)
    {
        int dayInt;
        if (int.TryParse(day, out dayInt) && dayInt >= 0)
        {
            DateTime dayTime;
            if (TrySetData(DateTime.Year, DateTime.Month, dayInt, out dayTime))
            {
                DateTime = dayTime;
                LastDay = dayInt;
            }
        }

        ResetDay();
    }

    public void ResetYear()
    {
        Year.text = LastYear.ToString();
        SetDateText();
    }

    public void ResetMonth()
    {
        Month.text = LastMonth.ToString();
        SetDateText();
    }

    public void ResetDay()
    {
        Day.text = LastDay.ToString();
        SetDateText();
    }

    public void SetDateText()
    {
        Text.text = DateTime.ToShortDateString();
    }

    public void OnCancel()
    {
        gameObject.SetActive(false);
    }

    public void OnAccept()
    {
        gameObject.SetActive(false);
        OnDatePicked.Invoke(DateTime);
    }

    private bool TrySetData(int year, int month, int day, out DateTime dateTime)
    {
        dateTime = new DateTime();
        try
        {
            dateTime = new DateTime(year, month, day);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
