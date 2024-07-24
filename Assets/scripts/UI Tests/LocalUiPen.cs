using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class LocalUiPen : MonoBehaviour
{
    
    /// <summary>
    /// This scripts enables the 3 peice radial menu to translate, scale, and rotate the last object painted
    /// within the 3d space. 
    /// </summary>
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject cursorTemp;
    [SerializeField] private Transform UITransform;
    [SerializeField] private GameObject ParentUIChildObject;

    [SerializeField] private PenRotateOther _penRotate;
    [FormerlySerializedAs("_penScale")] [SerializeField] private PenTranslateOther penTranslateOtherScale;
    //[SerializeField] private 
    private void Update()
    {
        UiPressAction();
    }

    private void UiPressAction()
    {
        
        Vector3 offsetposition = new Vector3(Pen.current.position.ReadValue().x, Pen.current.position.ReadValue().y,
            UITransform.position.z);
        cursorTemp.transform.position = _camera.ScreenToViewportPoint(offsetposition);

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
