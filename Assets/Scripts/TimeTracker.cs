using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    /// <summary>
    /// A float between 0 and 1 that returns the time passed since the beginning of the day (00:00 - 23:59)
    /// </summary>
    public float DayProgress;

    public int DayOfWeek { get; private set; }   // 1-7
    public int DayOfMonth { get; private set; }  // 1-31
    public int Month { get; private set; }      // 1-12
    public int Year { get; private set; }

    private void Start()
    {
        UpdateDate();
    }

    private void Update()
    {
        UpdateDayProgress();
        UpdateDate();
    }

    void UpdateDayProgress()
    {
        // Get the current time in hours and minutes
        float currentHour = DateTime.Now.Hour;
        float currentMinute = DateTime.Now.Minute;
        float currentSecond = DateTime.Now.Second;

        // Calculate the total seconds passed since midnight
        float totalMinutesPassed = (currentHour * 60 * 60) + (currentMinute * 60) + currentSecond;

        // Calculate the percentage of the day that has passed
        DayProgress = totalMinutesPassed / (24 * 60 * 60);

        // Clamp the percentage between 0 and 1
        DayProgress = Mathf.Clamp01(DayProgress);
    }

    void UpdateDate()
    {
        DayOfWeek = (int)DateTime.Now.DayOfWeek;
        DayOfMonth = DateTime.Now.Day;
        Month = DateTime.Now.Month;
        Year = DateTime.Now.Year;
    }

    public string getDayOfWeekString()
    {
        switch (DayOfWeek)
        {
            case 1:
                return "Monday";
            case 2:
                return "Tuesday";
            case 3:
                return "Wednesday";
            case 4:
                return "Thursday";
            case 5:
                return "Friday";
            case 6:
                return "Saturday";
            case 7:
                return "Sunday";
            default:
                return "DayOfWeek";
        }
    }

    public string getMonthString()
    {
        switch (Month)
        {
            case 1:
                return "January";
            case 2:
                return "February";
            case 3:
                return "March";
            case 4:
                return "April";
            case 5:
                return "May";
            case 6:
                return "June";
            case 7:
                return "July";
            case 8:
                return "August";
            case 9:
                return "September";
            case 10:
                return "October";
            case 11:
                return "November";
            case 12:
                return "December";
            default:
                return "Month";
        }
    }
}
