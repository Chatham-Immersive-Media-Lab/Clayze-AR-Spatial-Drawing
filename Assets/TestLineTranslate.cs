using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class TestLineTranslate : MonoBehaviour
{
    public LineRenderer LineRendererPub;

    private Vector2 startPosition;
    private Vector3 ChangedDistnacePostion;
    private void Update()
    {
        TranslateLineRender();
    }

    private void TranslateLineRender()
    {
        if (Pen.current.tip.IsPressed())
        {
            DistanceAdd();
            AdditionToLinePoints();
        }
    }

    private void AdditionToLinePoints()
    {
        for (int i = 0; i < LineRendererPub.positionCount; i++)
        {
            LineRendererPub.SetPosition(i, LineRendererPub.GetPosition(i) - ChangedDistnacePostion / 150);
        }
    }

    private void DistanceAdd()
    {
        if (Pen.current.tip.wasPressedThisFrame)
        {
             startPosition = new Vector2(Pen.current.position.x.value, Pen.current.position.y.value);
        }
        else if (Pen.current.tip.IsPressed())
        {
            float a = startPosition.x - Pen.current.position.x.value;
            float b = startPosition.y - Pen.current.position.y.value;

            ChangedDistnacePostion = new Vector3(a, 0, b);
        }
    }
}
