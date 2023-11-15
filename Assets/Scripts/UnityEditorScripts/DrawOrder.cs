using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;
using UnityEditor;

[ExecuteInEditMode]
public class DrawOrder : MonoBehaviour
{
    public float test = 1;
    public List<ListWrapper<GameObject>> layers = new List<ListWrapper<GameObject>>();

    public void UpdateOrders()
    {
        for (int layer = 0; layer < layers.Count; layer++)
        {
            foreach (GameObject obj in layers[layer].list)
            {
                if (obj != null)
                {
                    TextMeshPro text = (TextMeshPro)obj.GetComponent<TMP_Text>();
                    SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

                    if (text)
                    {
                        text.sortingOrder = layer;
                    }
                    else if (spriteRenderer)
                    {
                        spriteRenderer.sortingOrder = layer;
                    }
                }
            }
        }
    }
}

[CustomEditor(typeof(DrawOrder))]
public class CustomInspectorButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DrawOrder drawOrder = (DrawOrder)target;

        if (GUILayout.Button("Update Order"))
        {
            drawOrder.UpdateOrders();
        }
    }
}