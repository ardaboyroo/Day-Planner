using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnPanelOpen : MonoBehaviour
{
    public ActivityCreator creator;
    private BoxCollider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (col == null)
        {
            col = GetComponent<BoxCollider>();
        }

        if (creator.isCreatorPanelOpen)
        {
            col.enabled = false;
        }
        else
        {
            col.enabled = true;
        }
    }
}
