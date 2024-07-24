using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PenTranslateOther : MonoBehaviour
{
    [SerializeField] private GameObject parentScaleObject;
    private Vector3 scaleValueVector3;
    private Vector3 canvasOffsetPosition;

    private Vector3 penStartPosition;
    [SerializeField] private Vector3 totalPenTravel;
    void Start()
    {
        GetParentScale();
        canvasOffsetPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        TranslatePenCanvas();
    }

    private void GetParentScale()
    {
        scaleValueVector3 = parentScaleObject.transform.localScale;
        
    }

    public void SetParentScale()
    {
        // I would like to change the value of an object based on the abs value in dinstance from one point
        // of a pen stroke to another.
        
        //how do I want this to start? I think barrel button 2 for now will be used for scaling the object, and
        // pulling it towards the user.
        
        // I wounder if the user could choose which one they would like to use at the same time...
        
        // And does the scale happen at the point of brush stroke
        
        // Do I prototype a sort of physical gear for scaling the object??
        
        //Pen.current.position.value
    }

    public void TranslatePenCanvas()
    {
        float XPenVal = transform.position.x;
        float YPenVal = transform.position.y;
        
        // I need to get the distance formula for the z axis and the x axis. The z axis will be replaced
        // By the pens value of y/

        Vector3 penToCanvasVector3  = new Vector3(XPenVal, 0, YPenVal);
        Vector3 offestVector3 = penToCanvasVector3 - parentScaleObject.transform.position;

        Vector3 trainformSwitched = new Vector3(transform.position.x, 0, transform.position.y);
        Vector3 penStartSwitched = new Vector3(penStartPosition.x, 0, penStartPosition.y);
        
        if (Pen.current.tip.wasPressedThisFrame)
        {
            penStartPosition = transform.position;
            Debug.Log("pressed, and set");
            Debug.Log(penStartPosition);
        }
        
        if (Pen.current.tip.IsPressed())
        {
            //I need to drag the position of the other object relative to the other. I need to get the vector 3
            //offset between the center of each object, offest that then att the difference in change.
            parentScaleObject.transform.position = penToCanvasVector3 - canvasOffsetPosition ;
        }

        if (Pen.current.tip.wasReleasedThisFrame)
        {
            totalPenTravel -= trainformSwitched + penStartSwitched;
            
            canvasOffsetPosition = totalPenTravel;
            Debug.Log("released");
        }
    }
    
}
