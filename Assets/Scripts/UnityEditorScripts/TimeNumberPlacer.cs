using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class TimeNumberPlacer : MonoBehaviour
{
    private List<GameObject> nums;
    private List<GameObject> stripes;

    public Vector2 numsOffset = new Vector2(-2.8f, -0.94f);
    public Vector2 stripesOffset = new Vector2(0, -0.94f);

    void Awake()
    {
        nums = new List<GameObject>();
        stripes = new List<GameObject>();

        foreach (Transform child in transform)
        {
            if (child.GetComponent<TMP_Text>())
                nums.Add(child.gameObject);
            
            else if (child.GetComponent<SpriteRenderer>())
                stripes.Add(child.gameObject);
        }
    }

    void Update()
    {
        for (int i = 0; i < nums.Count; i++)
        {
            nums[i].transform.localPosition = new Vector3(numsOffset.x, numsOffset.y * (i + 1), 0);

            string num;

            if (i < 10)
                num = "0" + i.ToString();
            else
                num = i.ToString();

            nums[i].GetComponent<TMP_Text>().text = num + ":00";
        }

        for (int i = 0; i < stripes.Count; i++)
        {
            stripes[i].transform.localPosition = new Vector3(stripesOffset.x, stripesOffset.y * (i + 1), 0);
        }
    }
}
