using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PenInteractor : MonoBehaviour
{
    /// <summary>
    /// This controls a line renederes position data in space by using a pen tablets display.
    /// </summary>

    [SerializeField] private Camera _camera;
    
    [SerializeField] private LineRenderer _lineRenderer;

    [SerializeField] private GameObject cursorTemp;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        TipPressedAction();
    }

    private void TipPressedAction()
    {
        cursorTemp.transform.position = _camera.ScreenToViewportPoint(Pen.current.position.ReadValue());
        if (Pen.current.tip.IsPressed())
        {
            // Vector2 tempScreenSpacePenVector2 =
            //     new Vector2(Mathf.Clamp(Pen.current.position.value.normalized.x, 0f, _camera.pixelWidth),
            //         Mathf.Clamp(Pen.current.position.value.normalized.y, 0f, _camera.pixelHeight));
            
            Debug.Log("pressed");
            
        }
    }
    
    

    private void LineRenderAdd()
    {
        
    }
}
