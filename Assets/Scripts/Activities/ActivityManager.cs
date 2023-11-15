using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ActivityManager : MonoBehaviour
{
    public static ActivityManager instance { get; private set; }

    [SerializeField] private ActivityCreator creator;

    private List<GameObject> activities;

    [SerializeField] private Transform begin;
    [SerializeField] private Transform end;

    // Create a singleton
    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Activity Manager");
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        activities = new List<GameObject>();
        //savesList = new ListWrapper<Activity>();

        //savesList.list.Add(new Activity(0.0f, 1.0f, "first Save"));
        //savesList.list.Add(new Activity(0.5f, 0.75f, "second Save"));
        //Activity saveAct = new Activity(0.0f, 1.0f, "second Save");

        //string json = JsonUtility.ToJson(savesList);
        //Debug.Log(json);

        //Activity loadedAct = JsonUtility.FromJson<Activity>(json);
        //Debug.Log(loadedAct.title);

        //if (Directory.Exists(Application.dataPath + "/Data"))
        //{
        //    // Writes to given path (Creates if it doesn't exist)
        //    File.WriteAllText(Application.dataPath + "/Data/save.txt", json);
        //}
        //else
        //{
        //    Directory.CreateDirectory(Application.dataPath + "/Data");
        //    File.WriteAllText(Application.dataPath + "/Data/save.txt", json);
        //}
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(activities.Count);
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void Load()
    {
        string saveString = File.ReadAllText(Application.dataPath + "/Data/save.txt");
        ListWrapper<Activity> savedActivities = JsonUtility.FromJson<ListWrapper<Activity>>(saveString);

        foreach (Activity act in savedActivities.list)
        {
            AddActivity(creator.InstantiateActivity(act));
        }
    }

    private void Save()
    {
        // get activities from the save file
        // get activities from current session
        // Merge them
        // save the new activities
        ListWrapper<Activity> savedActivities = new ListWrapper<Activity>();

        // From GameObject to Activity
        // All activities to json
        foreach (GameObject currentActivity in activities)
        {
            float posY = currentActivity.transform.position.y;
            float currentActivityScaleY = currentActivity.transform.localScale.y;

            // Find out begin time by looking at its position
            float reversedBeginTime = (posY + currentActivityScaleY / 2 - begin.position.y) / (end.position.y - begin.position.y);

            // Find out how long the task takes by looking at its localSize.y
            float duration = currentActivityScaleY / Mathf.Abs(end.position.y - begin.position.y);

            Activity act = new Activity(reversedBeginTime, reversedBeginTime+duration, currentActivity.GetComponentInChildren<TMP_Text>().text);
            savedActivities.list.Add(act);
        }

        string toSave = JsonUtility.ToJson(savedActivities);
        if (Directory.Exists(Application.dataPath + "/Data"))
        {
            // Writes to given path (Creates if it doesn't exist)
            File.WriteAllText(Application.dataPath + "/Data/save.txt", toSave);
        }
        else
        {
            // Create directory before writing
            Directory.CreateDirectory(Application.dataPath + "/Data");
            File.WriteAllText(Application.dataPath + "/Data/save.txt", toSave);
        }
    }

    public void DestroyActivity(GameObject obj)
    {
        Destroy(obj);
        activities.Remove(obj);
    }

    public void AddActivity(GameObject obj)
    {
        activities.Add(obj);
    }
}
