using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
public class PenErase : MonoBehaviour
{
    [SerializeField] private GameObject eraseObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PenInput)"))
        {
            Destroy(other.gameObject);
        }
    }
}
