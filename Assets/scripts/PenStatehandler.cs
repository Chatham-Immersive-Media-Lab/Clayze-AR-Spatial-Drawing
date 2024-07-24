using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PenStatehandler : MonoBehaviour
{
    /// <summary>
    /// This is a amalgamation of all other movement scripts into a attempted working prototype.
    /// Taking public functions from 3 separate scripts, it only references others as a singleton behavior.
    /// </summary>
    
    [SerializeField] private GameObject DrawnObjectParent;
    [SerializeField] private List<GameObject> drawnObjectList = new List<GameObject>();
    private GameObject _lastDrawnObject;
    [Space]
    private Vector3 canvasOffsetPosition;
    private Vector3 penStartPosition;
    [SerializeField] private Vector3 totalPenTravel;
    [Space]
    public int stateInt = 0;
    [Space] 
    [SerializeField] private PenInput3D _penInput3D;
    public GameObject drawingObjectParent;
    void Start()
    {
        canvasOffsetPosition = new Vector3(0, 0, 0);

        
    }

    // Update is called once per frame
    void Update()
    {
        ChosenPenState();

        if (Pen.current.tip.wasReleasedThisFrame)
        {
            GetChildObjects();
            Debug.Log("CheckedList");
        }
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

    private void GetChildObjects()
    {
        drawnObjectList.Clear();
        foreach (Transform childObject in drawingObjectParent.GetComponentsInChildren<Transform>())
        {
            drawnObjectList.Add(childObject.gameObject);
        }

        _lastDrawnObject = drawnObjectList.Last();
    }
    public void ChosenPenState()
    {
        //each behavior needs to get the current newly instantiated object in the scene... how can I do that.
        if (stateInt == 0)
        { 
            _penInput3D.HunterPenBehavior();   
        }
        else if (stateInt == 1)
        {
            RotationState();
        }
        else if (stateInt == 2)
        {
            TranslateState();
        }
        else if (stateInt == 3)
        {
            ScaleState();
        }
    }
    
    private void RotationState()
    {
        if (Pen.current.tip.IsPressed())
        {
            float penTiltY = Pen.current.tilt.value.y;
            float penTiltX = Pen.current.tilt.value.x;
            Vector3 normal = Vector3.up;
            Vector3 tiltDir = new Vector3(penTiltX, 0, -penTiltY);
            _lastDrawnObject.transform.rotation = Quaternion.AngleAxis(Mathf.Max( Mathf.Abs(penTiltX),Mathf.Abs(penTiltY))  * 90, 
                Vector3.Cross( normal,tiltDir).normalized);
            Debug.Log("we are rotating?");
        }
    }

    public void TranslateState()
    {
        float XPenVal = transform.position.x;
        float YPenVal = transform.position.y;

        Vector3 penToCanvasVector3  = new Vector3(XPenVal, 0, YPenVal);
        Vector3 offestVector3 = penToCanvasVector3 - DrawnObjectParent.transform.position;

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
            DrawnObjectParent.transform.position = penToCanvasVector3 - canvasOffsetPosition ;
        }

        if (Pen.current.tip.wasReleasedThisFrame)
        {
            totalPenTravel += trainformSwitched  - penStartSwitched;
            
            canvasOffsetPosition = totalPenTravel;
            Debug.Log("released");
        }
    }

    private void ScaleState()
    {
        
    }
}
