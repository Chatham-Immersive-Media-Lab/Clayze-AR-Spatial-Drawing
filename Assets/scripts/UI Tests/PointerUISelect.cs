using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerUISelect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LocalUiPen _localUiPen;
    [SerializeField] private PenStatehandler _penStatehandler;

    private void OnTriggerEnter(Collider other)
    {
        //go take a look at the PenStateHandler for my arbitrary number method;
        if (other.CompareTag("EraseOrbUI"))
        {
            Debug.Log("EraseOrb Selected");
            _penStatehandler.state = PenInputState.Scale;
            _localUiPen.RadialDisable();
        }
        else if (other.CompareTag("TranslateOrbUI"))
        {
            Debug.Log("TranslateOrb Selected");
            _penStatehandler.state = PenInputState.Translating;
            _localUiPen.RadialDisable();
        }
        else if (other.CompareTag("RotateOrbUI"))
        {
            Debug.Log("RotateOrb Selected");
            _penStatehandler.state = PenInputState.Rotating;
            _localUiPen.RadialDisable();
        }
        else if (other.CompareTag("DrawOrbUI"))
        {
            //what a nightmare of a choice here! this goes against the whole deal here...
            //there is no UI showing this, god heck!
            _penStatehandler.state = PenInputState.Drawing;
            _localUiPen.RadialDisable();
        }
    }
}
