using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent uEvent = new UnityEvent();

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

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                uEvent.Invoke();
            }
        }
    }

    public void TestMethod()
    {
        Debug.Log("Clicked");
    }
}
