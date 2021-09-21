using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    private Vector2Int coordinate = new Vector2Int();
    private int i;
    private int j;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            CoordinateDisplay();
            UpdateObjName();
        }
    }

    private void CoordinateDisplay()
    {
        coordinate.x = 7 - Mathf.RoundToInt(transform.parent.position.z / EditorSnapSettings.move.z);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.x / EditorSnapSettings.move.x);
        i = coordinate.x;
        j = coordinate.y;

        textMeshPro.text = $"{i},{j}";
    }

    private void UpdateObjName()
    {
        transform.parent.name = coordinate.ToString();
    }

    public void SetTextBox(int[,] values)
    {
        CoordinateDisplay();
        if (values.GetLength(0) < i + 1 || values.GetLength(1) < j + 1)
        {
            Debug.LogError("Bad Index");
            return;
        }

        textMeshPro.text = values[i, j].ToString();
    }
}
