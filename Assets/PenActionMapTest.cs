using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PenActionMapTest : MonoBehaviour
{

    public InputActionAsset inputActionAsset;

    private InputAction _penTouchAction;

    private void Awake()
    {
        _penTouchAction = inputActionAsset.FindActionMap("Drawing Map").FindAction("PenTap");
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Pen.current.IsPressed())
        {
            Debug.Log("I have the pressed!");
        }
    }

    private void OnEnable()
    {
        inputActionAsset.FindActionMap("Drawing Map").Enable();
    }

    private void OnDisable()
    {
        inputActionAsset.FindActionMap("Drawing Map").Disable();
    }
}
