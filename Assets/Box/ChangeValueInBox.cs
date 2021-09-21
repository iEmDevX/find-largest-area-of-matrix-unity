using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeValueInBox : MonoBehaviour
{

    private bool active = false;
    private bool isMouseOver;

    private Color defaultColor;
    private Color activeColor = Color.blue;
    private int x;
    private int y;

    private GameObject objParent;
    private BoxController boxController;
    private TextResultController textResultController;

    Dictionary<KeyCode, int> keyMap = new Dictionary<KeyCode, int>()
    {
        { KeyCode.Alpha0, 0 },
        { KeyCode.Alpha1, 1 },
        { KeyCode.Alpha2, 2 },
        { KeyCode.Alpha3, 3 },
        { KeyCode.Alpha4, 4 },
        { KeyCode.Alpha5, 5 },
        { KeyCode.Alpha6, 6 },
        { KeyCode.Alpha7, 7 },
        { KeyCode.Alpha8, 8 },
        { KeyCode.Alpha9, 9 },
        { KeyCode.Keypad0, 0 },
        { KeyCode.Keypad1, 1 },
        { KeyCode.Keypad2, 2 },
        { KeyCode.Keypad3, 3 },
        { KeyCode.Keypad4, 4 },
        { KeyCode.Keypad5, 5 },
        { KeyCode.Keypad6, 6 },
        { KeyCode.Keypad7, 7 },
        { KeyCode.Keypad8, 8 },
        { KeyCode.Keypad9, 9 },
    };

    private void Start()
    {

        defaultColor = GetComponent<MeshRenderer>().material.color;
        boxController = FindObjectOfType<BoxController>();
        textResultController = FindObjectOfType<TextResultController>();

        objParent = transform.parent.gameObject;
        var name = objParent.name.Replace("(", "")
            .Replace(")", "")
            .Split(',');
        x = int.Parse(name[1]);
        y = int.Parse(name[0]);
    }

    private void Update()
    {
        OnKeyBoardInput();
    }

    public void OnKeyBoardInput()
    {
        if (!isMouseOver) return;
        foreach (var item in keyMap)
        {
            if (Input.GetKeyDown(item.Key))
            {
                int numberPressed = item.Value;
                boxController.ResetMax();
                boxController.UpdateValue(x, y, numberPressed);
            }
        }
    }

    private void OnMouseOver()
    {
        if (isMouseOver) return;

        isMouseOver = true;
        ChangeColor();
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (active)
        {
            this.active = false;
            GetComponent<MeshRenderer>().material.color = defaultColor;
        }
        else
        {
            this.active = true;
            GetComponent<MeshRenderer>().material.color = activeColor;
        }
    }
}
