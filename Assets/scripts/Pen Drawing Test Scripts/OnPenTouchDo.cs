using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnPenTouchDo : MonoBehaviour
{
    // Start is called before the first frame update

    public InputActionAsset inputActionAsset;

    private InputAction _penTouchAction;

    private void Awake()
    {
        _penTouchAction = inputActionAsset.FindActionMap("Drawing Map").FindAction("PenTap");
    }
    

    // Update is called once per frame
    void Update()
    {
        //pen update wrapper???
        //how do I get the action and look for when the PenTap action is called?
        // if (Pen.current == null)
        // {
        //     return;
        // }
        
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
