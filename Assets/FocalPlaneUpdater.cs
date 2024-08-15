using System.Collections;
using System.Collections.Generic;
using LookingGlass;
using UnityEngine;

public class FocalPlaneUpdater : MonoBehaviour
{
    public Transform _drawDepth;

    private HologramCamera _cam;

    void Awake()
    {
        _cam = GetComponent<HologramCamera>();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,_drawDepth.transform.position.z);
    }
}
