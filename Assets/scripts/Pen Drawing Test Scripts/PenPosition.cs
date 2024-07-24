using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PenPosition : MonoBehaviour
{
    /// <summary>
    /// This controls a line renederes position data in space by using a pen tablets display.
    /// </summary>

    [SerializeField] private Camera _camera;

    [SerializeField] private GameObject cursorTemp;

    private void Update()
    {
        TipPressedAction();
    }

    private void TipPressedAction()
    {
        Vector3 screenPoint = new Vector3(Pen.current.position.x.value, Pen.current.position.y.value, 10);
        cursorTemp.transform.position = _camera.ScreenToWorldPoint(screenPoint);
       
        if (Pen.current.tip.IsPressed())
        {
            return;
        }
        
    }
}
