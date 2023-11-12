using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateTitle : MonoBehaviour
{
    private TimeTracker tracker;
    private TMP_Text label;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.Find("TimeTracker").GetComponent<TimeTracker>();
        label = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        label.text = tracker.DayOfMonth + " " + tracker.getMonthString() + " " + tracker.Year;
    }
}
