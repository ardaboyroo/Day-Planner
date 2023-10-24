using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TestLabelScript : MonoBehaviour
{
    public TMP_Text m_TextMeshPro;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        m_TextMeshPro.text = DateTime.Now.ToString();
        
    }
}
