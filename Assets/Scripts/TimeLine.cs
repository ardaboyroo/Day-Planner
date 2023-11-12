using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLine : MonoBehaviour
{
    public Transform begin;
    public Transform end;

    private TimeTracker tracker;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.Find("TimeTracker").GetComponent<TimeTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        float posY = Mathf.Lerp(begin.position.y, end.position.y, tracker.DayProgress);
        transform.position = new Vector3(0, posY, 0);
    }
}
