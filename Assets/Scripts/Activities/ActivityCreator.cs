using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ActivityCreator : MonoBehaviour
{
    public static ActivityCreator instance { get; private set; }

    [SerializeField]public bool isCreatorPanelOpen { get; private set;}

    public Sprite baseSprite;

    public Activity activity;

    public TMP_Text beginHourText;
    public TMP_Text beginMinuteText;
    public TMP_Text endHourText;
    public TMP_Text endMinuteText;
    public TMP_Text titleText;

    [SerializeField] public ActivityManager activityManager;

    private TimeTracker tracker;

    [SerializeField] private Transform creatorPanelPivot;
    [SerializeField] private Transform begin;
    [SerializeField] private Transform end;

    private Activity test;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Activity Creator");
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.Find("TimeTracker").GetComponent<TimeTracker>();

        isCreatorPanelOpen = false;

        if (activityManager == null)
            Debug.LogError("Activity Manager field not set to an Instance");

        if (baseSprite == null)
            Debug.LogWarning("Base Sprite has not been set to an Instance");


        test = new Activity(new Vector3(15, 0), new Vector3(16, 0), "Test Activity");
    }

    // Update is called once per frame
    void Update()
    {
        if (isCreatorPanelOpen)
        {
            UpdateActivity();
        }
    }

    public void ToggleCreatorPanel()
    {
        isCreatorPanelOpen = !isCreatorPanelOpen;

        if (isCreatorPanelOpen)
        {
            creatorPanelPivot.localPosition = new Vector3(-3.75f, 0, 1);
        }
        else
        {
            activityManager.AddActivity(InstantiateActivity(activity));
            creatorPanelPivot.localPosition = new Vector3(3.75f, 0, 1);
        }
    }

    private void UpdateActivity()
    {
        activity.title = titleText.text;

        int beginHour;
        int beginMinute;
        if (int.TryParse(beginHourText.text, out beginHour) && int.TryParse(beginMinuteText.text, out beginMinute))
            activity.beginTime = TimeTracker.TimeToDayProgress(beginHour, beginMinute,0);
        else
            activity.beginTime = 0f;
        
        int endHour;
        int endMinute;
        if (int.TryParse(endHourText.text, out endHour) && int.TryParse(endMinuteText.text, out endMinute))
            activity.endTime = TimeTracker.TimeToDayProgress(endHour, endMinute,0);
        else
            activity.endTime = 0f;
    }

    public GameObject InstantiateActivity(Activity activity)
    {
        Debug.Log("end Time: " + activity.endTime);
        GameObject newActivity = new GameObject(activity.title);
        GameObject childText = new GameObject("Title");

        newActivity.AddComponent<SpriteRenderer>();

        Button activityButton = newActivity.AddComponent<Button>();
        activityButton.button = Button.MouseButtons.RightMouseButton;
        activityButton.uEvent.AddListener(obj => activityManager.DestroyActivity(obj));

        SpriteRenderer sprite = newActivity.GetComponent<SpriteRenderer>();
        sprite.color = new Color(0.1411712f, 0.7619635f, 0.9716981f);
        sprite.sprite = baseSprite;
        sprite.sortingOrder = 2;


        float scaleY = Mathf.Abs((end.position.y - begin.position.y) * (activity.endTime - activity.beginTime));
        newActivity.transform.localScale = new Vector3(4.8f, scaleY);

        float posY = Mathf.Lerp(begin.position.y, end.position.y, activity.beginTime) - newActivity.transform.localScale.y/2;
        newActivity.transform.position = new Vector3(0.5f, posY);


        TextMeshPro text = childText.AddComponent<TextMeshPro>();
        text.text = activity.title;
        text.fontStyle = FontStyles.Bold;
        text.color = Color.white;
        text.fontSize = 3f;
        text.sortingOrder = 2;
        text.margin = new Vector4(-1.8f, 0.025f, -1.8f, 0.025f);

        RectTransform textTransform = text.GetComponent<RectTransform>();
        // Set the width and height to 1, 1 (20, 5 is default -_-)
        textTransform.sizeDelta = new Vector2(1, 1);

        // Set the text object parent to the activity object
        // while keeping it's world position the same
        childText.transform.SetParent(newActivity.transform, true);

        textTransform.localPosition = new Vector3(0, 0);

        return newActivity;
    }
}
