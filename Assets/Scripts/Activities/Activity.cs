using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Activity
{
    public string date;

    public float beginTime;
    public float endTime;

    public string title;

    public Activity() { }

    public Activity(Vector2 begin, Vector2 end, string title)
    {
        beginTime = TimeTracker.TimeToDayProgress((int)begin.x, (int)begin.y, 0);
        endTime = TimeTracker.TimeToDayProgress((int)end.x, (int)end.y, 0);

        this.title = title;
    }
}
