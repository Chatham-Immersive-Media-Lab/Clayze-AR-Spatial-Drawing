using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class LocalUiPen : MonoBehaviour
{
    
    /// <summary>
    /// This scripts enables the 3 piece radial menu to translate, erase, and rotate the last object painted
    /// within the 3d space. 
    /// </summary>
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject cursorTemp;
    [SerializeField] private Transform UITransform;
    [SerializeField] private GameObject ParentUIChildObject;
    [Space]
    [SerializeField] private PenStatehandler _PenStatehandler;
    private void Update()
    {
        UiPressAction();
    }
    
    private void UiPressAction()
    {
        
        Vector3 offsetposition = new Vector3(Pen.current.position.x.value, Pen.current.position.y.value,
            3);
        cursorTemp.transform.position = _camera.ScreenToWorldPoint(offsetposition);

        if (!Pen.current.firstBarrelButton.wasPressedThisFrame)
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
