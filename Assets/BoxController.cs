using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField]
    int[,] number = new int[,] {
                {0, 0, 0, 2, 2},//0
                {1, 1, 7, 2, 2},//1
                {2, 2, 7, 2, 1},//2
                {2, 1, 7, 4, 4},//3
                {2, 7, 7, 4, 4},//4
                {4, 6, 6, 0, 4},//5
                {4, 4, 6, 4, 4},//6
                {4, 4, 6, 4, 4}, //7
            };

    private bool log = false;

    void Start()
    {
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
            if (!log)
            {
                coordinateLabel.Print();
            }
            coordinateLabel.SetTextBox(number);
        }
        log = true;
    }
}
