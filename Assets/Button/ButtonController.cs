using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    [SerializeField] BoxController boxController;

    private void Awake()
    {
        if (boxController == null)
        {
            boxController = FindObjectOfType<BoxController>();
        }
    }

    public void PrintTest()
    {
        Debug.Log("Test from ButtonController");
    }

    public void HandleClickCalculate()
    {
        boxController.CalculateLargest();
    }

    public void HandleClickRandomNewNumber()
    {
        boxController.RandomNewNumber();
    }
}
