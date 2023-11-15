using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public enum MouseButtons
    {
        LeftMouseButton,
        RightMouseButton,
        MiddleMouseButton
    }

    public MouseButtons button = MouseButtons.LeftMouseButton;

    public UnityEvent<GameObject> uEvent = new UnityEvent<GameObject>();

    void Start()
    {
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
        bc.size = new Vector3(1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown((int)button))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Give gameObject as argument for methods that require a GameObject argument
                // such as ActivityManager.DestroyActivity()
                uEvent.Invoke(gameObject);
            }
        }
    }
}
