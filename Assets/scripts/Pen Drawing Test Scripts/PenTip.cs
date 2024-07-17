using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PenTip : MonoBehaviour
{
    private void Update()
    {
        TipPressedAction();
    }

    void TipPressedAction()
    {
        if (Pen.current.tip.IsPressed())
        {
            Debug.Log("pressed");
        }
    }
}
