using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    /// <summary>
    /// A float between 0 and 1 that returns the time passed since the beginning of the day (00:00 - 23:59)
    /// </summary>
    [SerializeField]
    public float DayProgress;

    public int DayOfWeek { get; private set;}
    public int DayOfMonth { get; private set;}
    public int Month { get; private set; }
    public int Year { get; private set; }

    private void Start()
    {
        DayOfWeek = (int)DateTime.Now.DayOfWeek;
        DayOfMonth = DateTime.Now.Day;
        Month = DateTime.Now.Month;
        Year = DateTime.Now.Year;

        Debug.Log($"DayOfWeek: {DayOfWeek}");
        Debug.Log($"DayOfMonth: {DayOfMonth}");
        Debug.Log($"Month: {Month}");
        Debug.Log($"Year: {Year}");

        Debug.Log(string.Format("{0}", DateTime.Now));
    }

    private void Update()
    {
        UpdateDayProgress();
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
}
