using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerUISelect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LocalUiPen _localUiPen;
    [SerializeField] private PenStatehandler _penStatehandler;

    private void OnTriggerEnter(Collider other)
    {
        //go take a look at the PenStateHandler for my arbitrary number method;
        if (other.CompareTag("ScaleOrbUI"))
        {
            Debug.Log("scaleOrb Selected");
            _penStatehandler.stateInt = 3;
            _localUiPen.RadialDisable();
        }
        else if (other.CompareTag("TranslateOrbUI"))
        {
            Debug.Log("translateOrb Selected");
            _penStatehandler.stateInt = 2;
            _localUiPen.RadialDisable();
        }
        else if (other.CompareTag("RotateOrbUI"))
        {
            Debug.Log("rotateOrb Selected");
            _penStatehandler.stateInt = 1;
            _localUiPen.RadialDisable();
        }
        else if (Pen.current.tip.wasPressedThisFrame)
        {
            //what a nightmare of a choice here! this goes against the whole deal here...
            //there is no UI showing this, god heck!
            _penStatehandler.stateInt = 0;
        }
    }
}
