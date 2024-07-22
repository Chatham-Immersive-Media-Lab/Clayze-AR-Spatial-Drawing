using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerUISelect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LocalUiPen _localUiPen;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScaleOrbUI"))
        {
            Debug.Log("scaleOrb Selected");
            _localUiPen.RadialDisable();
        }
        else if (other.CompareTag("TranslateOrbUI"))
        {
            Debug.Log("translateOrb Selected");
            _localUiPen.RadialDisable();
        }
        
    }
}
