using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class TextInput : MonoBehaviour
{
    public TMP_Text text;

    public bool onlyDigits = false;

    public bool IsFocused { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        IsFocused = false;
        if (text == null)
        {
            Debug.LogError("TextMesh not assigned to the TextInput script");
        }
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
        bc.size = new Vector3(1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CheckFocused();
        if (IsFocused)
            HandleInput();
    }

    void CheckFocused()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                IsFocused = true;
            }
            else
            {
                IsFocused = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return) && IsFocused)
        {
            IsFocused = false;
        }
    }

    void HandleInput()
    {
        foreach (char c in Input.inputString)
        {
            if (onlyDigits)
            {

                if (char.IsDigit(c))
                {
                    UpdateText(c);
                }
            }
            else
            {
                if (char.IsLetterOrDigit(c))
                {
                    UpdateText(c);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace) && text.text.Length > 0)
        {
            DeleteLastCharacter();
        }
    }

    void UpdateText(char c)
    {
        text.text += c;
    }

    void DeleteLastCharacter()
    {
        text.text = text.text.Substring(0, text.text.Length - 1);
    }
}
