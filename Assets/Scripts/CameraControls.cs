using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Transform end;
    public float scrollSensitivity = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float posY = Mathf.Clamp(transform.position.y + Input.mouseScrollDelta.y * scrollSensitivity, 10 - end.localScale.y, 0);

        transform.position = new Vector3(0, posY, -1);
    }
}
