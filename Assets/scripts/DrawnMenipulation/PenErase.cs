using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
public class PenErase : MonoBehaviour
{
    [SerializeField] private GameObject eraseObject;

    void Start()
    {
        Destroy(this.gameObject);
    }
}
