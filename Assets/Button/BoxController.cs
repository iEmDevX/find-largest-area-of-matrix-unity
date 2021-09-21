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
    List<MatrixValue> biggestArea = new List<MatrixValue>();

    Dictionary<string, GameObject> obgDir = new Dictionary<string, GameObject>();
    Dictionary<string, ChangeValueInBox> changeValueInBoxList = new Dictionary<string, ChangeValueInBox>();

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

    private void Start()
    {
        GameObject[] boxs = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxs)
        {

            var coordinateLabel = box.GetComponentInChildren<CoordinateLabel>();
            coordinateLabel.SetTextBox(values);

            var changeValueInBox = box.GetComponentInChildren<ChangeValueInBox>();
            changeValueInBoxList.Add(changeValueInBox.x.ToString() + changeValueInBox.y.ToString(), changeValueInBox);

            obgDir.Add(changeValueInBox.x.ToString() + changeValueInBox.y.ToString(), box);
        }
    }

    void Update()
    {
        SetValue();
    }

    private void SetValue()
    {
        foreach (var obj in obgDir)
        {
            var coordinateLabel = obj.Value.GetComponentInChildren<CoordinateLabel>();
            coordinateLabel.SetTextBox(values);
        }
    }

    public void CalculateLargest()
    {
        if (largestElement != -1) return;

        var matrix = new Matrix(values);
        largestElement = matrix.FindCountElementOfBiggestArea();
        textResultController.SetMax(largestElement);
        biggestArea = matrix.BiggestArea;
        Debug.Log(biggestArea);
        SetAnswerColor();
    }

    private void SetAnswerColor()
    {
        foreach (var item in biggestArea)
        {
            GameObject obj;
            obgDir.TryGetValue(item.X.ToString() + item.Y.ToString(), out obj);
            ChangeValueInBox ch = obj.GetComponentInChildren<ChangeValueInBox>();
            ch.SetAnswerColor();
        }
    }

    private void SetDefualtColor()
    {
        foreach (var item in biggestArea)
        {
            GameObject obj;
            obgDir.TryGetValue(item.X.ToString() + item.Y.ToString(), out obj);
            ChangeValueInBox ch = obj.GetComponentInChildren<ChangeValueInBox>();
            ch.ResetColor();
        }
    }

    public void RandomNewNumber()
    {
        ResetMax();
        GenarateRandomNewNumber();
    }

    public void ResetMax()
    {
        SetDefualtColor();
        biggestArea.Clear();
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
