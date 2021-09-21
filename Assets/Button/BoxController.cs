using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MatrixProblem;

public class BoxController : MonoBehaviour
{
    [SerializeField]
    int[,] values = new int[,] {
                {0, 0, 0, 2, 2}, //0
                {1, 1, 7, 2, 2}, //1
                {2, 2, 7, 2, 1}, //2
                {2, 1, 7, 4, 4}, //3
                {2, 7, 7, 4, 4}, //4
                {4, 6, 6, 0, 4}, //5
                {4, 4, 6, 4, 4}, //6
                {4, 4, 6, 4, 4}, //7
            };

    [SerializeField] TextResultController textResultController;

    public int largestElement = -1;
    private int xLength = 5;
    private int yLength = 8;

    private void Awake()
    {
        if (textResultController == null)
        {
            textResultController = FindObjectOfType<TextResultController>();
        }
    }

    void Update()
    {
        SetValue();
    }

    private void SetValue()
    {
        GameObject[] boxs = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxs)
        {
            var coordinateLabel = box.GetComponentInChildren<CoordinateLabel>();
            coordinateLabel.SetTextBox(values);
        }
    }

    public void CalculateLargest()
    {
        if (largestElement != -1) return;

        var matrix = new Matrix(values);
        largestElement = matrix.FindCountElementOfBiggestArea();
        textResultController.SetMax(largestElement);
    }

    public void RandomNewNumber()
    {
        largestElement = -1;
        textResultController.ResetMax();
        GenarateRandomNewNumber();
    }

    public void ResetMax()
    {
        largestElement = -1;
        textResultController.ResetMax();
    }

    private void GenarateRandomNewNumber()
    {
        for (int i = 0; i < xLength; ++i)
        {
            for (int j = 0; j < yLength; ++j)
            {
                values[j, i] = Random.Range(0, 10);
            }
        }
    }

    public void UpdateValue(int x, int y, int value)
    {
        values[y, x] = value;
    }


}
