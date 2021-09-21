using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextResultController : MonoBehaviour
{
    private Text textMesh;

    private void Awake()
    {
        textMesh = GetComponent<Text>();
    }

    private void Start()
    {
        ResetMax();
    }

    public void ResetMax()
    {
        textMesh.text = "Please Click Calulate Button";
    }

    public void SetMax(int max)
    {
        textMesh.text = $"Largest Area of this Matrix is { max.ToString()} elements";
    }
}
