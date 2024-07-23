using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrawBehavior : MonoBehaviour
{
    // we need a on draw, a during draw, and a exit draw modality
    // the on draw will spawn in a new object with a 

    [SerializeField] private Transform ParentalTransformObject;
    [SerializeField] private GameObject LineRendererObject;

    public Transform penTransform;
    private LineRenderer _lineRenderer;

    private GameObject SelectedObject;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BeginDraw()
    {
        if (Pen.current.tip.wasPressedThisFrame)
        {
            SelectedObject = Instantiate(LineRendererObject, ParentalTransformObject);
            
        }

        if (Pen.current.tip.IsPressed())
        {
            _lineRenderer.positionCount++;
            _lineRenderer.SetPosition(_lineRenderer.positionCount ,penTransform.position);
        }
    }
}
