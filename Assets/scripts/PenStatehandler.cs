using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public PenInputState state = 0;
    [Space] 
    [SerializeField] private PenInput3D _penInput3D;
    public GameObject drawingObjectParent;
    
    //[SerializeField] private LineRenderer lineRenderer;
    private Vector2 startPosition;
    private Vector3 ChangedDistnacePostion;
    void Start()
    {
        canvasOffsetPosition = new Vector3(0, 0, 0);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == PenInputState.Drawing)
        {
            _penInput3D.HunterPenBehavior();
        }
        else if (state == PenInputState.Rotating)
        {
            RotationTick();
        }
        else if (state == PenInputState.Scale)
        {
            TranslateLineRenderTick();
        }
        else if (state == PenInputState.Translating)
        {
            ScaleStateTick();
        }
        
        
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

    private void RotationTick()
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

    private void TranslateLineRenderTick()
    {
        if (Pen.current.tip.IsPressed())
        {
            DistanceAdd();
            AdditionToLinePoints();
        }
    }

    private void AdditionToLinePoints()
    {
        LineRenderer drawnObjectLine = _lastDrawnObject.GetComponent<LineRenderer>();
        for (int i = 0; i < drawnObjectLine.positionCount; i++)
        {
            drawnObjectLine.SetPosition(i, drawnObjectLine.GetPosition(i) - ChangedDistnacePostion / 150);
        }
    }

    private void DistanceAdd()
    {
        if (Pen.current.tip.wasPressedThisFrame)
        {
            startPosition = new Vector2(Pen.current.position.x.value, Pen.current.position.y.value);
        }
        else if (Pen.current.tip.IsPressed())
        {
            float a = startPosition.x - Pen.current.position.x.value;
            float b = startPosition.y - Pen.current.position.y.value;

            ChangedDistnacePostion = new Vector3(a, 0, b);
        }
    }

    private void ScaleStateTick()
    {
        
    }
}
