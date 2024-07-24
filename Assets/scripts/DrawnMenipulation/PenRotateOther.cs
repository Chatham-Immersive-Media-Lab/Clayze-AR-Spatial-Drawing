using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PenRotateOther : MonoBehaviour
{
    [SerializeField] private GameObject rotationObject;

    public Vector2Control penTiltExposedVar;
    
    // Update is called once per frame

    void Update()
    {
        OnPenBarrel();
    }

    private void OnPenBarrel()
    {
        if (Pen.current.tip.IsPressed())
        {
            float penTiltY = Pen.current.tilt.value.y;
            float penTiltX = Pen.current.tilt.value.x;
            Vector3 normal = Vector3.up;
            Vector3 tiltDir = new Vector3(penTiltX, 0, -penTiltY);
            rotationObject.transform.rotation = Quaternion.AngleAxis(Mathf.Max( Mathf.Abs(penTiltX),Mathf.Abs(penTiltY))  * 90, 
                Vector3.Cross( normal,tiltDir).normalized);
            Debug.Log("we are rotating?");
        }
    }
}
