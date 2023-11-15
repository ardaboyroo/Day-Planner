using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityManager : MonoBehaviour
{
    public static ActivityManager instance { get; private set;}

    private List<GameObject> activities;

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
    }

    // Update is called once per frame
    void Update()
    {
        
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
