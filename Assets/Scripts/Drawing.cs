using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;


public class Drawing : MonoBehaviour
{
    public InputActionReference drawReference = null;
    public GameObject marker;
    public GameObject cube;
    
    private void Awake()
    {
        drawReference.action.started += Draw;
    }

    private void OnDestroy()
    {
        drawReference.action.started -= Draw;
    }

    private void Draw(InputAction.CallbackContext context)
    {
        marker.GetComponent<WBMarker>().enabled = !marker.GetComponent<WBMarker>().enabled;
        bool isActive = !cube.activeSelf;
        cube.SetActive(isActive);
    }
}
