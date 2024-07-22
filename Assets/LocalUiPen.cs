using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalUiPen : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject cursorTemp;
    [SerializeField] private Transform UITransform;

    [SerializeField] private GameObject ParentUIChildObject;
    private void Update()
    {
        TipPressedAction();
    }

    private void TipPressedAction()
    {
        
        Vector3 offsetposition = new Vector3(Pen.current.position.ReadValue().x, Pen.current.position.ReadValue().y,
            UITransform.position.z);
        cursorTemp.transform.position = _camera.ScreenToViewportPoint(offsetposition);

        if (!Pen.current.tip.wasPressedThisFrame)
        {
            return;
        }
        else
        {
            RadialEnable();
        }
    }

    public void RadialEnable()
    {
        ParentUIChildObject.SetActive(true);
    }

    public void RadialDisable()
    {
        ParentUIChildObject.SetActive(false);
    }
}
